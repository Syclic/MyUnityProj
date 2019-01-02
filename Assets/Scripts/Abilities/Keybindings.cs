using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Keybindings")]
public class Keybindings : ScriptableObject
{
    public KeyCode jump, pause, inventory, characterSheet;
    public KeyCode abilityBar0, abilityBar1, abilityBar2, abilityBar3, abilityBar4, abilityBar5, abilityBar6, abilityBar7, abilityBar8, abilityBar9, abilityBar10, abilityBar11, abilityBar12;

    public KeyCode CheckKey(string key)
    {
        switch (key)
        {
            case "Jump":
                return jump;
            case "Pause":
                return pause;
            case "Inventory":
                return inventory;
            case "CharacterSheet":
                return characterSheet;
            case "MainBar0":
                return abilityBar0;
            case "MainBar1":
                return abilityBar1;
            case "MainBar2":
                return abilityBar2;
            case "MainBar3":
                return abilityBar3;
            case "MainBar4":
                return abilityBar4;
            case "MainBar5":
                return abilityBar5;
            case "MainBar6":
                return abilityBar6;
            case "MainBar7":
                return abilityBar7;
            case "MainBar8":
                return abilityBar8;
            case "MainBar9":
                return abilityBar9;
            case "MainBar10":
                return abilityBar10;
            case "MainBar11":
                return abilityBar11;
            case "MainBar12":
                return abilityBar12;
            default:
                return KeyCode.None;
        }
    }
}
