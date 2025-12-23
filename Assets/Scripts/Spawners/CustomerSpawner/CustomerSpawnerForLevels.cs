using ForLevels;
using Slimes;
using UnityEngine;

namespace Spawners
{
    public class CustomerSpawnerForLevels : CustomerSpawner
    {
        private BasketSpawnerForLevels _slimeSpawnerForLevels;
        private CounterForLevels _counter;

        public override void SpawnCustomer()
        {
            if (_spawnedCustomer != null)
            {
                Destroy(_spawnedCustomer.gameObject);
                _spawnedCustomer = null;
            }

            _spawnedCustomer = Instantiate(
                _customerPrefabs[Random.Range(0, _customerPrefabs.Count)], _spawnPosition.position,
                Quaternion.Euler(0, -90, 0), this.transform);

            _spawnedCustomer.SetPosition(_positionToStay.position);

            if (_slimeSpawnerForLevels.SpawnedSlimes.Count > 0)
            {
                _spawnedCustomer.SetWantedColor(_slimeSpawnerForLevels.SpawnedSlimes[0].GetColor());
                _taskVisualizer.SetWantedColor(_spawnedCustomer.WantedColor);
                _deliveryPoint.SetWantedColor(_slimeSpawnerForLevels.SpawnedSlimes[0].GetColor());
            }

            _spawnedCustomer.SetSound(_customerSound);
            _spawnedCustomer.GoToPosition();
        }

        public void SetValues(BaseBasketSpawner spawner, CounterForLevels counter)
        {
            _slimeSpawnerForLevels = (BasketSpawnerForLevels)spawner;
            _counter = counter;
            _slimeSpawnerForLevels.Spawning += SpawnCustomer;
        }

        protected override void RespawnCustomer(Slime slime)
        {
            if (_counter != null && _counter.OrdersCount != _counter.StandartOrdersCount)
            {
                _slimeSpawnerForLevels.DeleteSlimeFromList(slime);
                SpawnCustomer();
            }
        }
    }
}