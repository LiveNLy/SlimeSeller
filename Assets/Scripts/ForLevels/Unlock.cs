using UnityEngine;

public class Unlock : MonoBehaviour
{
    [SerializeField] private Basket _lockedBasket;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Basket>(out Basket basket))
        {
            _spriteRenderer.gameObject.SetActive(false);

            if (_lockedBasket != null && _lockedBasket.IsBlocked == false)
            {
                _lockedBasket.MakeMoveble();
            }

            gameObject.SetActive(false);
        }
    }
}