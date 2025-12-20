using ForLevels;
using UnityEngine;

namespace UI
{
    public class OrderCounter : CounterForLevels
    {
        [SerializeField] private Score _score;

        private int _customersToScore = 5;

        public override void OnStart()
        {
            _ordersCount = 0;
            _text.text = _ordersCount.ToString();
        }

        public override void AddScore()
        {
            _ordersCount++;
            _text.text = _ordersCount.ToString();
        }

        public void ConvertOnEnd(float timerNumber)
        {
            _score.AddScore(_ordersCount * _customersToScore);
        }
    }
}