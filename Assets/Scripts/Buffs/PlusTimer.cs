using Interfaces;
using UnityEngine;

namespace Buffs
{
    public class PlusTimer : BuffClick
    {
        private const int _effectPower = 10;

        private ITool _timer;

        public override void ApplyEffect()
        {
            Debug.Log(_timer);
            _timer.ApplyEffect(_effectPower);
        }

        public override void SetTool(ITool timer)
        {
            _timer = timer;
        }
    }
}