using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public Transform player;

    public void Use(GameObject usedAbility)
    {
        Ability ability = usedAbility.GetComponent<Ability>();
        float usedRange = Mathf.Clamp(player.GetComponent<CharacterManager>().reticle.localPosition.z, ability.minCastRange, ability.maxCastRange);
        GameObject spellClone = Instantiate(usedAbility, player.position + player.forward * usedRange + new Vector3(0, 1.5f, 0), player.rotation);
        Destroy(spellClone, ability.duration);
    }

    private void Update()
    {
        if (PlayerManager.instance.KeyDown("MainBar1"))
        {
            GameObject abilityBox = EquipmentManager.instance.spellbook[6];
            if (abilityBox != null && EquipmentManager.instance.spellbookCDs[6] <= 0)
            {
                Use(abilityBox);
                EquipmentManager.instance.spellbookCDs[6] = abilityBox.GetComponent<Ability>().coolDown;
            }
        }
        if (PlayerManager.instance.KeyDown("MainBar2"))
        {
            GameObject abilityBox = EquipmentManager.instance.spellbook[7];
            if (abilityBox != null && EquipmentManager.instance.spellbookCDs[7] <= 0)
            {
                Use(abilityBox);
                EquipmentManager.instance.spellbookCDs[7] = abilityBox.GetComponent<Ability>().coolDown;
            }
        }
        if (PlayerManager.instance.KeyDown("MainBar3"))
        {
            GameObject abilityBox = EquipmentManager.instance.spellbook[8];
            if (abilityBox != null && EquipmentManager.instance.spellbookCDs[8] <= 0)
            {
                Use(abilityBox);
                EquipmentManager.instance.spellbookCDs[8] = abilityBox.GetComponent<Ability>().coolDown;
            }
        }
        if (PlayerManager.instance.KeyDown("MainBar4"))
        {
            GameObject abilityBox = EquipmentManager.instance.spellbook[9];
            if (abilityBox != null && EquipmentManager.instance.spellbookCDs[9] <= 0)
            {
                Use(abilityBox);
                EquipmentManager.instance.spellbookCDs[9] = abilityBox.GetComponent<Ability>().coolDown;
            }
        }
    }
}
