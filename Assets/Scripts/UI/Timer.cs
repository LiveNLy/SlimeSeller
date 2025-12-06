using TMPro;
using UnityEngine;
using YG;

public class Timer : Tool, ITimer
{
    [SerializeField] private TextMeshProUGUI _textTimer;
    [SerializeField] private BaseBasketSpawner _slimeSpawner;
    [SerializeField] private CustomerSpawner _customerSpawner;
    [SerializeField] private RestarWindow _winWindow;
    [SerializeField] private RestarWindow _loseWindow;
    [SerializeField] private float _standartTimerTime;
    [SerializeField] private AudioSource _loseSound;
    [SerializeField] private AudioSource _winSound;

    private float _timer;
    private float _zero = 0f;
    private bool _isTimeEnd = false;

    public float TimerNumber => _timer;

    private void Start()
    {
        RestartTimer();
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        _textTimer.text = _timer.ToString("F2");

        if (_timer < _zero)
        {
            if (!_isTimeEnd)
            {
                MakeLoseScreen();
            }
        }
    }

    public void RestartTimer()
    {
        YG2.SaveProgress();
        Time.timeScale = 1f;
        _timer = _standartTimerTime;
        _isTimeEnd = false;
    }

    public void DoConverce(float points)
    {
        _timer += points;
    }

    public void MakeWinScreen()
    {
        _slimeSpawner.RemoveBasketsOnLose();
        _customerSpawner.ChangeCustomerOnWin();
        _winSound.Play();
        _winWindow.gameObject.SetActive(true);
        _isTimeEnd = true;
        YG2.SaveProgress();
        Time.timeScale = 0;
    }

    private void MakeLoseScreen()
    {
        _slimeSpawner.RemoveBasketsOnLose();
        _customerSpawner.ChangeCustomerOnLose();
        _loseSound.Play();
        _loseWindow.gameObject.SetActive(true);
        _isTimeEnd = true;
        YG2.SaveProgress();
        Time.timeScale = 0;
    }
}