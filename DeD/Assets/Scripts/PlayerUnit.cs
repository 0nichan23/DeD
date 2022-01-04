using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public float Initiative;
    public float Attack;
    public float Hp;
    public float MaxHp;
    //public int[] actionValues = new int[4];
    public float Energy;
    public float MaxEnergy;
    public Transform pos;
    public static int KillCount;
    public int levelAtstart;
    public GameObject SpellList;
    public static Spell spellIndex;
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
        Hp = MaxHp;
        Energy = MaxEnergy;
        KillCount = 0;
        level = levelAtstart;
        spellIndex = null;
    }

    public void Strike(EnemyUnit enemy)
    {
        BattleText.Instance.changeText("player used strike");
        enemy.TakeDmg(Attack);
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
                    if (Hp+spellIndex.dmg >= MaxHp)
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
}
