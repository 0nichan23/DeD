using System.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    bool combatEnded = false;
    [SerializeField]
    private float turnDelay;
    public PlayerUnit _player;
    EnemyUnit _enemy;
    public GameObject CombatUI;
    public GameObject map;
    public GameObject UI;
    public Bar PlayerHpBar;
    public Bar PlayerEnergyBar;
    public Bar EnemyHpBar;
    public Bar EnemyEnergyBar;
    public GameObject SpellList;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int? attackNum = null;
    IEnumerator BattleLoop()
    {
        while (combatEnded == false)
        {
            if (_player.Initiative >= _enemy.Initiative)
            {
                yield return new WaitUntil(() => attackNum != null);
                _player.StartAction((int)attackNum, _enemy);
                SpellList.SetActive(false);
                attackNum = null;
                UpdateBars();
                yield return new WaitForSeconds(turnDelay);

                if (CheckCombatEnded())
                {
                    BattleText.Instance.changeText("u defeated the enemy");
                    yield return new WaitForSeconds(turnDelay);
                    StopBattleLoop(true);
                }
                else
                {
                    _enemy.EnemyAction(_player);
                    UpdateBars();

                    if (CheckCombatEnded())
                    {
                        BattleText.Instance.changeText("u died");
                        yield return new WaitForSeconds(turnDelay);
                        StopBattleLoop(false);
                    }
                }
            }
            else
            {
                yield return new WaitUntil(() => attackNum != null);
                _enemy.EnemyAction(_player);
                UpdateBars();
                yield return new WaitForSeconds(turnDelay);
                if (CheckCombatEnded())
                {
                    BattleText.Instance.changeText("u died");
                    yield return new WaitForSeconds(turnDelay);
                    StopBattleLoop(false);
                }
                else
                {
                    _player.StartAction((int)attackNum, _enemy);
                    SpellList.SetActive(false);
                    attackNum = null;
                    UpdateBars();
                    yield return new WaitForSeconds(turnDelay);
                    if (CheckCombatEnded())
                    {
                        BattleText.Instance.changeText("u defeated the enemy");
                        yield return new WaitForSeconds(turnDelay);
                        StopBattleLoop(true);
                    }
                }
            }
            yield return new WaitForSeconds(turnDelay);
        }
    }
    public void StopBattleLoop(bool victory)
    {
        if (victory)
        {
            _player.Xp += _enemy.xpValue;
            _player.CheckLevelUp();
            Destroy(_enemy.gameObject);
            END();
        }
        else
        {
            //gamemanager.losegame()
        }
        StopCoroutine("BattleLoop");
    }

    public void StartCombat(PlayerUnit player, EnemyUnit enemy)
    {
        map.SetActive(false);
        UI.SetActive(false);
        CombatUI.SetActive(true);
        _player = player;
        _enemy = enemy;
        SetupBars();
        UpdateBars();
        TurnSpellList();
        StartCoroutine("BattleLoop");
    }
    void UpdateBars()
    {
        EnemyHpBar.setValue(_enemy.Hp);
        EnemyEnergyBar.setValue(_enemy.Energy);
        PlayerHpBar.setValue(_player.Hp);
        PlayerEnergyBar.setValue(_player.Energy);
    }
    void SetupBars()
    {
        EnemyHpBar.SetMaxValue(_enemy.MaxHp);
        EnemyEnergyBar.SetMaxValue(_enemy.MaxEnergy);
        PlayerHpBar.SetMaxValue(_player.MaxHp);
        PlayerEnergyBar.SetMaxValue(_player.MaxEnergy);
        Debug.Log("bars set up");
    }

    public void SetAttackNumValue(int Num)
    {
        attackNum = Num;
    }

    public void TurnSpellList()
    {
        if (SpellList.activeSelf)
        {
            SpellList.SetActive(false);
        }
        else
        {
            SpellList.SetActive(true);
        }
    }

    bool CheckCombatEnded()
    {
        if (_player.Hp > 0 && _enemy.Hp > 0)
        {
            return false;
        }
        return true;
    }
    public void END()
    {
        map.SetActive(true);
        UI.SetActive(true);
        CombatUI.SetActive(false);
        BattleText.Instance.ResetText();
    }


}
