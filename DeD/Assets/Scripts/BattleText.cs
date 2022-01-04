using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleText : MonoBehaviour
{
    public static BattleText Instance;
    Text texty;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        texty = GetComponent<Text>();
    }

    public void changeText(string stufftosay)
    {
        texty.text = stufftosay;
    }

    public void ResetText()
    {
        texty.text = "";
    }
}
