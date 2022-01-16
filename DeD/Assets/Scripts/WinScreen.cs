using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Image ItemImage;
    public static WinScreen Instance;
    public PlayerUnit player;
    public EnemyUnit enemy;
    ItemDispplay Lootitem;
    private void Awake()
    {
        Instance = this;
       
    }

    public void ClaimLoot()
    {
        player.inventory.AddItem(Lootitem);
        BattleManager.Instance.END();
    }


    public void GenerateItem()
    {
        switch (Random.Range(1, 4))
        {
            case 1: Lootitem = CharacterMenu.Instance.HpPots; break;
            case 2: Lootitem = CharacterMenu.Instance.ManaPots; break;
            case 3: Lootitem = CharacterMenu.Instance.SwordDmg; break;
            default:
                break;
        }
        ItemImage.sprite = ItemAssets.Instance.GetSprite(Lootitem.refItem);
    }

    public void Set(bool on)
    {
        gameObject.SetActive(on);

    }

}
