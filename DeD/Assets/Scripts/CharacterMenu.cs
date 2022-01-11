using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public PlayerUnit player;
    public GameObject LevelUpui;
    public GameObject CharPage;
    public static CharacterMenu Instance;
    public Bar Hpbar;
    public Bar Manabar;
    public Bar Xpbar;
    public ItemDispplay SwordDmg;
    public ItemDispplay HpPots;
    public ItemDispplay ManaPots;
    
    
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
    public void TurnCharacterPage()
    {
        if (CharPage.activeSelf)
        {
            CharPage.SetActive(false);
        }
        else
        {
            CharPage.SetActive(true);
            SetUpBars();
            updateTexts();
            UpdateBars();
            if (player.levelUpReady)
            {
                LevelUpui.SetActive(true);
            }
            else
            {
                LevelUpui.SetActive(false);
            }
        }
    }



    public void UpdateBars()
    {
        Hpbar.setValue(player.Hp);
        Manabar.setValue(player.Energy);
        Xpbar.setValue(player.Xp);
    }

    public void SetUpBars()
    {
        Hpbar.SetMaxValue(player.MaxHp);
        Manabar.SetMaxValue(player.MaxEnergy);
        Xpbar.SetMaxValue(player.XpToNextLevel);
    }
    public void updateTexts()
    {
        float attack = player.Attack + SwordDmg.Dmg;
        text1.text = attack.ToString();
        text2.text = (player.SpellPower).ToString();
        text3.text = (player.Initiative).ToString();
        text4.text = PlayerUnit.level.ToString();
        SwordDmg.DmgValue.text = SwordDmg.Dmg.ToString();
        HpPots.AmountValue.text = HpPots.Amount.ToString();
        ManaPots.AmountValue.text = ManaPots.Amount.ToString();
    }


    public void ObtainHpPotion()
    {
        HpPots.Amount++;
    }
    public void ObtainManaPotion()
    {
        ManaPots.Amount++;
    }
    public void DrinkHpPot()
    {
        if (HpPots.Amount > 0 && player.Hp < player.MaxHp)
        {
            player.IncreseHp(20);
            HpPots.Amount--;
        }
        updateTexts();
        UpdateBars();
    }
    public void DrinkEnergyPot()
    {
        if (ManaPots.Amount >0 && player.Energy < player.MaxEnergy)
        {
            player.IncreseEnergy(20);
            ManaPots.Amount--;
        }
        updateTexts();
        UpdateBars();
    }
}
