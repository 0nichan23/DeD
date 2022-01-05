using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public float Initiative;
    public float Attack;
    public float Hp;
    public float MaxHp;
    public float Energy;
    public float MaxEnergy;
    public static int KillCount;
    public int levelAtstart;
    public static Spell spellIndex;
    public float Xp;
    public float XpToNextLevel;
    public float SpellPower;
    public float AttackDmg;
    public bool levelUpReady;
    public static int level { get; set; }
    public void StartAction(int value, EnemyUnit enemy)
    {
        Debug.Log("called");
        switch (value)
        {
            case 0:
                Strike(enemy);
                break;
            case 1:
                CastSpell(enemy);
                break;
            case 2:
                UseItem(/*Item item*/);
                break;
            case 3:
                Run(enemy);
                break;
            default:
                break;
        }
    }

    public void TakeDmg(float dmg)
    {
        Hp -= dmg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("start combat");
            EnemyUnit enemy = collision.gameObject.GetComponent<EnemyUnit>();
            BattleManager.Instance.StartCombat(this, enemy);
        }
    }

    private void Start()
    {

        KillCount = 0;
        level = levelAtstart;
        Xp = 0;
        XpToNextLevel = 10 + Mathf.Pow(2, level);
        AttackDmg = level + 2;
        SpellPower = level;
        Initiative = 7 + level;
        MaxHp = 10 * level;
        MaxEnergy = 10 * level;
        Hp = MaxHp;
        Energy = MaxEnergy;
        spellIndex = null;
    }

    public void Strike(EnemyUnit enemy)
    {
        BattleText.Instance.changeText("player used strike");
        enemy.TakeDmg(Attack + AttackDmg);
    }

    public void CastSpell(EnemyUnit enemy)
    {
        if (spellIndex != null)
        {
            if (Energy - spellIndex.cost >= 0)
            {
                Energy -= spellIndex.cost;
                if (spellIndex.name == "Heal")
                {
                    Hp += spellIndex.dmg;
                    if (Hp + spellIndex.dmg >= MaxHp)
                    {
                        Hp = MaxHp;
                    }
                }
                else
                {
                    enemy.TakeDmg(spellIndex.dmg);
                }
                BattleText.Instance.changeText("You cast the spell " + spellIndex.name + " and deal " + spellIndex.dmg);
            }
            else
            {
                BattleText.Instance.changeText("you dont have enough energy");
            }
            spellIndex = null;
        }

    }

    public void UseItem()
    {
        BattleText.Instance.changeText("player used an item");
    }

    public void Run(EnemyUnit enemy)
    {
        BattleText.Instance.changeText("player tried to run");
        if (Random.Range(0, 9) + (Initiative - enemy.Initiative) > 6)
        {
            BattleText.Instance.changeText("you managed to escape");
            BattleManager.Instance.END();
        }
        else
        {
            BattleText.Instance.changeText("you couldnt get away ");
        }
    }
    public void CheckLevelUp()
    {
        if (Xp >= XpToNextLevel)
        {
            Xp = Xp - XpToNextLevel;
            LevelUp();
        }
    }


    public void LevelUp()
    {
        MaxHp += 10;
        MaxEnergy += 10;
        Energy = MaxEnergy;
        Hp = MaxHp;
        XpToNextLevel = 10 + Mathf.Pow(2, level);
        levelUpReady = true;
    }


    public void IncreaseStat(int i)
    {
        switch (i)
        {
            case 1:
                AttackDmg++;
                break;
            case 2:
                SpellPower++;
                break;
            case 3:
                Initiative++;
                break;
            default:
                break;
        }
        levelUpReady = false;
        CharacterMenu.Instance.LevelUpui.SetActive(false);
    }
}
