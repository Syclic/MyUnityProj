using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainAttunement : Interactable
{
    public Attunement head, legs, rHand, lHand, voice;

    public override void Interact()
    {
        base.Interact();
        getAttunement(head);
        getAttunement(legs);
        getAttunement(rHand);
        getAttunement(lHand);
        getAttunement(voice);
    }
    void getAttunement(Attunement newAttunement)
    {
        Debug.Log("Drinking from " + transform.name);
        EquipmentManager.instance.Attune(newAttunement);
        //Pull up GUI for getting an attunement
    }
}
