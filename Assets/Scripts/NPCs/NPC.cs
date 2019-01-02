using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPC : ScriptableObject
{
    new public string name = "New NPC";
    public Sprite icon = null;
    public bool isDefaultNPC = false;

} 