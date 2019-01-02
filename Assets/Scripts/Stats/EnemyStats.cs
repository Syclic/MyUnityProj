using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private void Start()
    {
        vitalAura.SetValue(100);
    }
    public override void Die()
    {
        base.Die();
        //death animation
        Destroy(gameObject);
    }
}
