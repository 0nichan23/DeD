using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public float Initiative;
    public float Attack;
    public float Hp;
    public float MaxHp;
    public float Energy;
    public float MaxEnergy;
    int level;
    public int xpValue;
    public void TakeDmg(float dmg)
    {
        Hp -= dmg;
    }
    private void Start()
    {
        level = Random.Range(1, PlayerUnit.KillCount + 5);
        MaxHp = level + Mathf.Pow(level,2);
        MaxEnergy = level + 10;
        Hp = MaxHp;
        Energy = MaxEnergy;
        Initiative = Random.Range(PlayerUnit.level, PlayerUnit.level + 15);
        xpValue = (int)MaxHp - level;
        Attack = Random.Range(PlayerUnit.level + 5, PlayerUnit.level + 10);
    }


    public void EnemyAction(PlayerUnit player)
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                Bite(player);
                break;
            case 2:
                TailWhip(player);
                break;
            default:
                break;
        }
    }


    void Bite(PlayerUnit player)
    {
        player.TakeDmg(Attack + level);
        CombatAnimation.Instance.CrocBite();
        BattleText.Instance.changeText("enemy used bite and dealt " + (Attack + level));
    }
    void TailWhip(PlayerUnit player)
    {
        player.TakeDmg(Attack);
        CombatAnimation.Instance.CrocTailSmah();
        BattleText.Instance.changeText("enemy used tail smack and dealt " + Attack);
    }



}
