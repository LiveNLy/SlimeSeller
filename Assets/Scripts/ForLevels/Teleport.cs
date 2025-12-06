using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector3 _toPostion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Basket>(out Basket basket))
        {
            basket.transform.localPosition = _toPostion;
        }
    }
}