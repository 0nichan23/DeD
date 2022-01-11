using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Weapon,
        HpPot,
        ManaPot
    }
    
    public float Amount;
    public ItemType itemtype;
    public Sprite sprite;
    public bool StackAble;
    public void SetUp()
    {
        switch (itemtype)
        {
            case ItemType.Weapon:
                StackAble = false;
                break;
            case ItemType.HpPot:
            case ItemType.ManaPot:
                Amount = 1;
                StackAble = true;
                break;
        }
        sprite = ItemAssets.Instance.GetSprite(this);
    }

}
