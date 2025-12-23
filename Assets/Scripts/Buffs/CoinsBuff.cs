using Interfaces;
using UnityEngine;

namespace Buffs
{
    public class CoinsBuff : BuffClick
    {
        private const int _minCoin = 10;
        private const int _maxCoin = 20;

        private ITool _coins;
        private int _coinsToBeGiven;

        public override void ApplyEffect()
        {
            _coinsToBeGiven = Random.Range(_minCoin, _maxCoin);
            _coins.ApplyEffect(_coinsToBeGiven);
        }

        public override void SetTool(ITool coins)
        {
            _coins = coins;
        }
    }
}