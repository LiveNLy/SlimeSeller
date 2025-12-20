using Spawners.ForBasketSpawner;
using Spawners.ForCustomerSpawner;
using TMPro;
using UnityEngine;
using YG;
using Timescale;
using Interfaces;

namespace UI
{
    public class TimerForScoreMode : MonoBehaviour, ITool, ITimer
    {
        [SerializeField] private TextMeshProUGUI _textTimer;
        [SerializeField] private BasketSpawnerForRecordMode _slimeSpawner;
        [SerializeField] private CustomerSpawner _customerSpawner;
        [SerializeField] private Score _score;
        [SerializeField] private RestarWindow _restartWindow;
        [SerializeField] private float _standartTimerTime;
        [SerializeField] private AudioSource _winSound;
        [SerializeField] private PlusCoins _savedCoins;
        [SerializeField] private OrderCounter _orderCounter;
        [SerializeField] private TimescaleChanger _timescaler;

        private float _timer;
        private float _zero = 0f;
        private bool _isTimeEnd = false;

        private void Update()
        {
            _timer -= Time.deltaTime;
            _textTimer.text = _timer.ToString("F0") + " " + "сек";

            if (_timer < _zero)
            {
                if (!_isTimeEnd)
                {
                    MakeWinScreen();
                }
            }
        }

        public void RestartTimer()
        {
            YG2.SaveProgress();
            _timescaler.NormalizeTimescale();
            _timer = _standartTimerTime;
            _score.ResetScore();
            _isTimeEnd = false;
        }

        public void DoConverce(float points)
        {
            _timer += points;
        }

        public void MakeWinScreen()
        {
            _orderCounter.ConvertOnEnd(_timer);
            _slimeSpawner.RemoveBasketsOnLose();
            _customerSpawner.ChangeCustomerOnWin();
            _winSound.Play();
            _restartWindow.gameObject.SetActive(true);
            _savedCoins.WritePlusCoinsNumber(_score.ScoreNumber);
            _score.RestartScore();
            _savedCoins.ResetSavedCoinsNumber();
            _isTimeEnd = true;
            YG2.SaveProgress();
            _timescaler.StopTimescale();
        }

        public void ApplyEffect(int number)
        {
            DoConverce(number);
        }
    }
}