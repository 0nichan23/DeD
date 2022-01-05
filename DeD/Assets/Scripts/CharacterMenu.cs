using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public PlayerUnit player;
    public GameObject LevelUpui;
    public GameObject CharPage;
    public static CharacterMenu Instance;
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
            updateTexts();
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


    public void updateTexts()
    {
        text1.text = (player.Attack + player.AttackDmg).ToString();
        text2.text = (player.SpellPower).ToString();
        text3.text = (player.Initiative).ToString();
    }






}
