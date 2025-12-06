using UnityEngine;
using YG;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private BaseBasketSpawner _slimeSpawner;
    [SerializeField] private CustomerSpawner _customerSpawner;

    private bool _firstOpen = false;

    private void Start()
    {
        _customerSpawner.SetValues(_slimeSpawner);
        Restart();
    }

    public void Restart()
    {
        if (_firstOpen)
            _slimeSpawner.Respawn();

        _firstOpen = true;
    }
}