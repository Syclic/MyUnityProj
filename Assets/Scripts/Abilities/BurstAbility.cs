using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAbility : Ability
{
    void OnTriggerEnter(Collider collider)
    {
        GameObject target = collider.gameObject;
        if (collider.GetComponentInParent<EnemyStats>() != null)
        {
            EnemyStats enemy = collider.GetComponentInParent<EnemyStats>();
            Debug.Log("I see an enemy.");
            if (!targets.Contains(target))
            {
                enemy.TakeDamage(damage);
                Debug.Log("The " + target.name + " takes " + damage + " damage.");
            }
            targets.Add(target);
        }
    }
}
