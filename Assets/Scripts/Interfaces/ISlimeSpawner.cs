using System;
using UnityEngine;

public interface ISlimeSpawner
{
    public event Action Spawning;

    public bool DeleteSlimeFromList(Slime slime);

    public Color RandomColor();
}
