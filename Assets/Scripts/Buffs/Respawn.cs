using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : Effect
{
    private BasketSpawnerForRecordMode _spawner;

    public override void SetTool(Tool spawner)
    {
        _spawner = (BasketSpawnerForRecordMode)spawner;
    }

    public override void ApplyEffect()
    {
        _spawner.Respawn();
    }
}
