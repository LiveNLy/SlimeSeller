using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : Effect
{
    private SlimeSpawner _spawner;

    public override void SetTool(Tool spawner)
    {
        _spawner = (SlimeSpawner)spawner;
    }

    public override void ApplyEffect()
    {
        _spawner.Respawn();
    }
}
