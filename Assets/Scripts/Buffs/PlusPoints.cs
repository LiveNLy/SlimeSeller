using Interfaces;
using UnityEngine;

namespace Buffs
{
    public class PlusPoints : BuffClick
    {
        private ITool _score;
        private int _massivePoints;

        public override void ApplyEffect()
        {
            _massivePoints = Random.Range(50, 80);
            _score.ApplyEffect(_massivePoints);
        }

        public override void SetTool(ITool score)
        {
            _score = score;
        }
    }
}