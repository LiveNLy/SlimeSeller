using System;
using ForLevels;
using Interfaces;
using Slimes;
using Spawners.ForCustomerSpawner;
using UnityEngine;

namespace Spawners
{
    namespace ForBasketSpawner
    {
        public class DeliveryPoint : MonoBehaviour
        {
            [SerializeField] private AudioSource _effectSound;
            [SerializeField] private AudioSource _doneSound;
            [SerializeField] private ITimer _timer;
            [SerializeField] private Canvas _gameCanvas;
            [SerializeField] private CounterForLevels _counterForLevels;
            [SerializeField] private CustomerSpawner _customerSpawner;

            private Color _wantedColor;
            private float _secondsForTimer = 1f;

            public event Action<Slime> SlimeDelivered;

            private void Start()
            {
                _timer = _gameCanvas.GetComponentInChildren<ITimer>();
            }

            public bool ReturnSlime(Slime slime)
            {
                if (slime != null)
                {
                    if (slime.SlimeColor == _wantedColor)
                    {
                        _doneSound.Play();
                        _timer.DoConverce(_secondsForTimer);
                        _counterForLevels.AddScore();
                        SlimeDelivered?.Invoke(slime);
                        return true;
                    }
                }

                return false;
            }

            public void SetWantedColor(Color color)
            {
                _wantedColor = color;
            }
        }
    }
}