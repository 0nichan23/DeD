using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour
{
    public Spell Spell;
    public Text cost;
    public Text dmg;
    public new Text name;
    public Image art;
    public GameObject Locked;

    private void Start()
    {
        cost.text = Spell.cost.ToString();
        dmg.text = Spell.dmg.ToString();
        name.text = Spell.name;
        art.sprite = Spell.art;
    }

    private void OnEnable()
    {
        if (PlayerUnit.level >= Spell.RequiredLevel)
        {
            Locked.SetActive(false);
        }
    }
    /*  private void OnEnable()
      { 
          if (BattleManager.Instance._player.Energy - Spell.cost < 0)
          {
              gameObject.SetActive(false);
              Debug.Log("disabled spell");
          }
      }*/

    public void Cast()
    {
        PlayerUnit.spellIndex = Spell;
    }
}
