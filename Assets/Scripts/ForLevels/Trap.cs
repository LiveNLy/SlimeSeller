using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _lock;
    [SerializeField] private SpriteRenderer _blocked;
    [SerializeField] private Basket _basket;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Slime>(out Slime slime))
        {
            _lock.gameObject.SetActive(false);
            _blocked.gameObject.SetActive(true);
            Destroy(_basket.GetComponent<BasketMover>());
            Destroy(_basket.GetComponent<PositionSetter>());
            _basket.Block();
        }
    }
}