using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell : ScriptableObject
{
    public float cost;
    public int dmg;
    public new string name;
    public Sprite art;
    public int RequiredLevel;

}
