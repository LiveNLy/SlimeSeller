using System;
using Slimes;
using UnityEngine;

namespace Interfaces
{
    public interface ISlimeSpawner
    {
        public event Action Spawning;

        public bool DeleteSlimeFromList(Slime slime);

        public Color RandomColor();
    }
}