using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemDispplay> ItemList;
    private void Start()
    {
        ItemList = new List<ItemDispplay>();
    }

    public void AddItem(ItemDispplay item)
    {
        if (item.refItem.itemtype == Item.ItemType.HpPot)
        {
            CharacterMenu.Instance.ObtainHpPotion();
        }
        else if (item.refItem.itemtype == Item.ItemType.ManaPot)
        {
            CharacterMenu.Instance.ObtainManaPotion();
        }
        else
        {
            CharacterMenu.Instance.SwordDmg.Dmg++;
        }
        CharacterMenu.Instance.updateTexts();
    }


    public void IncreaseSword()
    {
        AddItem(CharacterMenu.Instance.SwordDmg);
    }
    public void IncreaseHppots()
    {
        AddItem(CharacterMenu.Instance.HpPots);
    }

    public void IncreaseManapots()
    {
        AddItem(CharacterMenu.Instance.HpPots);
    }



}
