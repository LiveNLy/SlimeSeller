using Interfaces;
using Spawners;
using Timescale;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI
{
    public class TimerForLevels : MonoBehaviour, ITimer
    {
        [SerializeField] private TextMeshProUGUI _textTimer;
        [SerializeField] private BaseBasketSpawner _slimeSpawner;
        [SerializeField] private CustomerSpawner _customerSpawner;
        [SerializeField] private RestarWindow _winWindow;
        [SerializeField] private float _standartTimerTime;
        [SerializeField] private AudioSource _winSound;
        [SerializeField] private Button _restartButton;
        [SerializeField] private TimescaleChanger _timescaler;

        private float _timer;
        private bool _isTimeEnd = false;

        public float Timer => _timer;

        private void Update()
        {
            if (!_isTimeEnd)
            {
                _timer += Time.deltaTime;
                _textTimer.text = _timer.ToString("F0");
            }
        }

        public void DoConverce(float points) { }

        public void RestartTimer()
        {
            YG2.SaveProgress();
            _isTimeEnd = false;
            _timescaler.NormalizeTimescale();
            _timer = _standartTimerTime;
        }

        public void MakeWinScreen()
        {
            _slimeSpawner.RemoveBasketsOnLose();
            _restartButton.gameObject.SetActive(false);
            _customerSpawner.ChangeCustomerOnWin();
            _winSound.Play();
            _winWindow.gameObject.SetActive(true);
            _winWindow.SetStats();
            _isTimeEnd = true;
            YG2.SaveProgress();
            _timescaler.StopTimescale();
        }
    }
}