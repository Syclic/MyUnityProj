using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;
    public Transform interactionTransform;
    Transform player;
    public virtual void Interact()
    {
        Debug.Log("Trying to Do Something");
    }    
}
