using Interfaces;
using System;
using UnityEngine;

namespace Inputs
{
    public class MouseInput : IInput
    {
        public event Action OnClickStarted;
        public event Action OnClickHeld;
        public event Action OnClickEnded;
        public event Action<Vector3> GetClickPosition;


        public void Update()
        {
            GetClickPosition?.Invoke(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                OnClickStarted?.Invoke();
            }

            if (Input.GetMouseButton(0))
            {
                OnClickHeld?.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnClickEnded?.Invoke();
            }
        }
    }
}