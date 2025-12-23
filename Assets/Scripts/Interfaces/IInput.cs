using System;
using UnityEngine;

namespace Interfaces
{
    public interface IInput
    {
        public event Action OnClickStarted;
        public event Action OnClickHeld;
        public event Action OnClickEnded;
        public event Action<Vector3> GetClickPosition;

        public void Update();
    }
}