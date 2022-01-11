using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDispplay : MonoBehaviour
{
    public Text DmgValue;
    public Text AmountValue;
    public Item refItem;
    public Image sprite;
    public float Dmg;
    public float Amount;
    private void Awake()
    {
        refItem.SetUp();
        if (refItem.itemtype == Item.ItemType.Weapon)
        {
            DmgValue.text = Dmg.ToString();
            GetDmg();
        }
        else 
        {
            AmountValue.text = Amount.ToString();
            Amount = 1;
        }
        sprite.sprite = refItem.sprite;
    }

    void GetDmg()
    {
        Dmg = Random.Range(PlayerUnit.level, PlayerUnit.level + 5);
    }



}
