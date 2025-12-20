using UnityEngine;

namespace Interfaces
{
    public interface IInput
    {
        public bool IsClickStarted();
        public bool IsClickHeld();
        public bool IsClickEnded();
        public Vector3 GetClickPosition();
        public bool HasClickInput();
    }
}