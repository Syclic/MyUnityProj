using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    new public string name = "New Ability";
    public Sprite icon = null;
    public Collider hitBox;
    public bool isDefaultAbility = false;
    public float damage, maxCastRange, minCastRange, duration, coolDown;
    public int abilityID;
    public HashSet<GameObject> targets = new HashSet<GameObject>();

    private void Awake()
    {
        hitBox = gameObject.GetComponent<Collider>();
    }
}