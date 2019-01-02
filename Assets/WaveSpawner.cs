using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : Spawner
{
    public override void OnTriggerEnter()
    {
        SpawnObject();
    }

    public override void OnTriggerExit()
    {

    }
}
