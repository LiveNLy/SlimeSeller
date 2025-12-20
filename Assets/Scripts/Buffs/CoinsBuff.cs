using Interfaces;
using UnityEngine;

namespace Buffs
{
    public class CoinsBuff : BuffClick
    {
        private ITool _coins;
        private int _coinsToBeGiven;

        public override void ApplyEffect()
        {
            _coinsToBeGiven = Random.Range(10, 20);
            _coins.ApplyEffect(_coinsToBeGiven);
        }

        public override void SetTool(ITool coins)
        {
            _coins = coins;
        }
    }
}