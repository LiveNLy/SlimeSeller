using Interfaces;
using UnityEngine;

namespace Buffs
{
    public class PlusPoints : BuffClick
    {
        private const int _minPoints = 50;
        private const int _maxPoints = 80;

        private ITool _score;
        private int _massivePoints;

        public override void ApplyEffect()
        {
            _massivePoints = Random.Range(_minPoints, _maxPoints);
            _score.ApplyEffect(_massivePoints);
        }

        public override void SetTool(ITool score)
        {
            _score = score;
        }
    }
}