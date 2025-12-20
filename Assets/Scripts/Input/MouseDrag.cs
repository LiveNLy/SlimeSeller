using Interfaces;
using UnityEngine;

namespace Inputs
{
    public class MouseDrag : IInput
    {
        public bool IsClickStarted()
        {
            return Input.GetMouseButtonDown(0);
        }

        public bool IsClickHeld()
        {
            return Input.GetMouseButton(0);
        }

        public bool IsClickEnded()
        {
            return Input.GetMouseButtonUp(0);
        }

        public Vector3 GetClickPosition()
        {
            return Input.mousePosition;
        }

        public bool HasClickInput()
        {
            return true;
        }
    }
}