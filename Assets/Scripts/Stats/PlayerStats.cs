using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        vitalAura.SetValue(60);
        potency.SetValue(10);
        deflect.SetValue(10);
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            deflect.AddModifier(newItem.armorModifier);
            potency.AddModifier(newItem.damageModifier);
        }
        
        if(oldItem != null)
        {
            deflect.RemoveModifier(oldItem.armorModifier);
            potency.RemoveModifier(oldItem.damageModifier);
        }
        
    }
}
