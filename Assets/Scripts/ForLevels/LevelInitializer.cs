using Spawners;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace ForLevels
{
    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField] private BaseBasketSpawner _spawner;
        [SerializeField] private CustomerSpawnerForLevels _spawnerCustomer;
        [SerializeField] private TimerForLevels _timer;
        [SerializeField] private CounterForLevels _counter;
        [SerializeField] private Image _silver;
        [SerializeField] private Image _gold;
        [SerializeField] private RestarWindow _restartWindow;

        private void Start()
        {
            _spawnerCustomer = GetComponentInChildren<CustomerSpawnerForLevels>();
            _restartWindow.SetStatsWindow();
            Color color = new Color(1, 1, 1, 0.5f);
            _silver.color = color;
            _gold.color = color;
            _restartWindow.gameObject.SetActive(false);
            _spawnerCustomer.SetValues(_spawner, _counter);
            OnStart();
        }

        private void OnStart()
        {
            _timer.RestartTimer();
            _counter.OnStart();
            _spawner.Respawn();
        }
    }
}