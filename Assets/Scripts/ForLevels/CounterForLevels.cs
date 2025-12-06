using TMPro;
using UnityEngine;

public class CounterForLevels : MonoBehaviour
{
    [SerializeField] private int _standartOrdersCount;
    [SerializeField] protected TextMeshProUGUI _text;
    [SerializeField] private TimerForLevels _timer;

    protected int _ordersCount;

    public int StandartOrdersCount => _standartOrdersCount;
    public int OrdersCount => _ordersCount;

    public virtual void OnStart()
    {
        _ordersCount = 0;
        _text.text = _ordersCount.ToString() + " из " + _standartOrdersCount;
    }

    public virtual void AddScore()
    {
        _ordersCount++;
        _text.text = _ordersCount.ToString() + " из " + _standartOrdersCount;

        if ( _ordersCount == _standartOrdersCount)
        {
            _timer.MakeWinScreen();
        }
    }
}