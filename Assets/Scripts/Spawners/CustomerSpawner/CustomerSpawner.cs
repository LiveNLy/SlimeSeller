using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] protected TaskVisualizer _taskVisualizer;
    [SerializeField] protected DeliveryPoint _deliveryPoint;
    [SerializeField] protected Transform _spawnPosition;
    [SerializeField] protected Transform _positionToStay;
    [SerializeField] protected List<Customer> _customerPrefabs;
    [SerializeField] protected AudioSource _customerSound;
    [SerializeField] private BasketSpawnerForRecordMode _slimeSpawner;
    [SerializeField] private OrderCounter _orderCounter;

    protected Customer _spawnedCustomer;

    private void OnEnable()
    {
        _deliveryPoint.SlimeDelivered += RespawnCustomer;
    }

    private void OnDisable()
    {
        _deliveryPoint.SlimeDelivered -= RespawnCustomer;
    }

    public void SetCustomerPosition()
    {
        _spawnedCustomer.SetPosition(_positionToStay.position);
    }

    public virtual void SpawnCustomer()
    {
        if (_spawnedCustomer != null)
        {
            Destroy(_spawnedCustomer.gameObject);
            _spawnedCustomer = null;
        }

        _spawnedCustomer = Instantiate(_customerPrefabs[Random.Range(0, _customerPrefabs.Count)], _spawnPosition.position, Quaternion.Euler(0, -90, 0), this.transform);
        SetCustomerPosition();
        _spawnedCustomer.SetWantedColor(_slimeSpawner.RandomColor());
        _taskVisualizer.SetWantedColor(_spawnedCustomer.WantedColor);
        _deliveryPoint.SetWantedColor(_spawnedCustomer.WantedColor);
        _spawnedCustomer.SetSound(_customerSound);
        _spawnedCustomer.GoToPosition();
    }

    public void ChangeCustomerOnLose()
    {
        _spawnedCustomer.OnLose();
    }

    public void ChangeCustomerOnWin()
    {
        _spawnedCustomer.OnWin();
    }

    public virtual void SetValues(BaseBasketSpawner spawner)
    {
        _slimeSpawner = (BasketSpawnerForRecordMode)spawner;
        _slimeSpawner.Spawning += SpawnCustomer;
    }

    protected virtual void RespawnCustomer(Slime slime)
    {
        if(_orderCounter != null)
        {
            _slimeSpawner.DeleteSlimeFromList(slime);
            SpawnCustomer();
        }
    }
}