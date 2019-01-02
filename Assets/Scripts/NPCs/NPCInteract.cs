using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : Interactable
{
    public NPC NPC;

    public override void Interact()
    {
        base.Interact();
        Talk();
    }
    void Talk()
    {
        Debug.Log("Talking with " + NPC.name);
        //bring up talking menu
    }
}
