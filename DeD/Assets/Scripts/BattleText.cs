using UnityEngine;
using UnityEngine.UI;

public class BattleText : MonoBehaviour
{
    public static BattleText Instance;
    Text texty;
    private void Awake()
    {
        Instance = this;
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
