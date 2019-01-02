using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstProj : Ability
{
    public int pierces = 1;
    public float projSpeed = 4f;

    private void Start()
    {
        transform.rotation = PlayerManager.instance.player.transform.rotation;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projSpeed);
    }

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
                pierces -= 1;
                Debug.Log("The " + target.name + " takes " + damage + " damage.");

            }
            targets.Add(target);
        }
        if (pierces <= 0)
        {
            Destroy(gameObject);
        }

    }
}
