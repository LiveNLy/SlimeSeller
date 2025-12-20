using System;
using UnityEngine;
using Slimes;

namespace Interfaces
{
    public interface ISlimeSpawner
    {
        public event Action Spawning;

        public bool DeleteSlimeFromList(Slime slime);

        public Color RandomColor();
    }
}