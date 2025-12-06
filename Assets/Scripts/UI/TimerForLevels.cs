using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class TimerForLevels : MonoBehaviour, ITimer
{
    [SerializeField] private TextMeshProUGUI _textTimer;
    [SerializeField] private BaseBasketSpawner _slimeSpawner;
    [SerializeField] private CustomerSpawner _customerSpawner;
    [SerializeField] private RestarWindow _winWindow;
    [SerializeField] private float _standartTimerTime;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private Button _restartButton;

    private float _timer;
    private bool _isTimeEnd = false;

    public float Timer => _timer;

    private void Update()
    {
        if (!_isTimeEnd)
        {
            _timer += Time.deltaTime;
            _textTimer.text = _timer.ToString("F0") + " " + "сек";
        }
    }

    public void DoConverce(float points)
    {

    }

    public void RestartTimer()
    {
        YG2.SaveProgress();
        _isTimeEnd = false;
        Time.timeScale = 1f;
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
        Time.timeScale = 0;
    }
}