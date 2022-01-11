using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance;
    public Sprite HpPot;
    public Sprite EnergyPot;
    public Sprite Weapon;
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


    public Sprite GetSprite(Item item)
    {
        switch (item.itemtype)
        {
            case Item.ItemType.Weapon:
                return Weapon;
            case Item.ItemType.HpPot:
                return HpPot;
            case Item.ItemType.ManaPot:
                return EnergyPot;
            default:
                return Weapon;
        }
    }
}
