using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        if (PlayerManager.instance.KeyDown("MainBar1"))
        {
            GameObject ability = EquipmentManager.instance.spellbook[6];
            if (ability != null)
            {
                GameObject spellClone = Instantiate(ability, player.position + player.forward * 5 + new Vector3(0, 1.5f, 0), player.rotation);
                Destroy(spellClone, ability.GetComponent<Ability>().duration);
            }
            else
            {
                Debug.Log("no ability available");
            }
        }
        if (PlayerManager.instance.KeyDown("MainBar2"))
        {
            if (EquipmentManager.instance.spellbook[7] != null)
            {
                
            }
            else
            {
                Debug.Log("no ability available");
            }
        }
        if (PlayerManager.instance.KeyDown("MainBar3"))
        {
            if (EquipmentManager.instance.spellbook[8] != null)
            {
                
            }
            else
            {
                Debug.Log("no ability available");
            }
        }
        if (PlayerManager.instance.KeyDown("MainBar4"))
        {
            if (EquipmentManager.instance.spellbook[9] != null)
            {
                
            }
            else
            {
                Debug.Log("no ability available");
            }
        }
    }
}
