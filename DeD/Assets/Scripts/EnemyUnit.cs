using System.Collections;
using System.Collections.Generic;
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
        Hp = MaxHp;
        Energy = MaxEnergy;
        level = Random.Range(PlayerUnit.KillCount, PlayerUnit.KillCount+5);
        xpValue = 3 + level;
    }

    public void EnemyAction(PlayerUnit player)
    {
        switch (Random.Range(1,3))
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
        BattleText.Instance.changeText("enemy used bite and dealt " + (Attack + level));

    }
    void TailWhip(PlayerUnit player)
    {
        player.TakeDmg(Attack);
        BattleText.Instance.changeText("enemy used bite and dealt " + Attack);
    }



}
