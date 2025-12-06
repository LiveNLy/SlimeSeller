using System.Collections.Generic;
using UnityEngine;

public class PositionSetter : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Transform _transform;
    private List<SpawnPoint> _validPoints = new List<SpawnPoint>();
    private float _sphereRadius = 0.8f;
    private float _sphereCorrector = 0.2f;
    private Vector3 _crossHorizontal = new Vector3(2.5f, 0.1f, 3);
    private Vector3 _crossVertical = new Vector3(0.5f, 2.5f, 3);

    private Vector3 position;
    float zCor;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetPosition(float zCorrecter, Slime slime, BasketMover mover)
    {
        int basketCount = 0;
        int groundCount = 0;
        bool isValid = false;
        position = _transform.position;
        zCor = zCorrecter;
        Collider[] colliders = Physics.OverlapSphere(new Vector3(position.x, position.y, position.z + zCor - _sphereCorrector), _sphereRadius);
        mover.SetStandartRotation();

        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<BaseBasketSpawner>())
                groundCount++;

            if (collider.GetComponent<Basket>())
                basketCount++;

            if (collider.TryGetComponent<SpawnPoint>(out SpawnPoint point))
            {
                if (_validPoints.Contains(point))
                {
                    isValid = point.CanGlow();
                    position = collider.transform.position;
                    position += new Vector3(0, 0, -0.5f);
                }
            }

            if (collider.TryGetComponent<DeliveryPoint>(out DeliveryPoint deliveryPoint))
            {
                if (isValid)
                {
                    if (deliveryPoint.ReturnSlime(slime))
                    {
                        ClearValidPoints();
                        Destroy(slime.gameObject);
                        ReturnToStartPosition();
                        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                        return;
                    }
                    else
                    {
                        ClearValidPoints();
                        ReturnToStartPosition();
                        return;
                    }
                }
            }
        }

        if (groundCount > 0 && isValid)
        {
            _transform.position = position;
        }
        else
        {
            ReturnToStartPosition();
        }

        ClearValidPoints();
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void GetValidPoints()
    {
        List<Collider> allColliders = new List<Collider>();

        Collider[] colliders = Physics.OverlapBox(_transform.position, _crossHorizontal);
        Collider[] colliders2 = Physics.OverlapBox(_transform.position, _crossVertical);

        allColliders.AddRange(colliders);
        allColliders.AddRange(colliders2);

        foreach (Collider collider in allColliders)
        {
            _validPoints.Add(collider.GetComponent<SpawnPoint>());
        }
    }

    public void UnfreezePosition()
    {
        _rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
        _rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
    }

    public void RememberFirstPosition()
    {
        _startPosition = _transform.position;
    }

    public void GlowPoints()
    {
        foreach (SpawnPoint point in _validPoints)
        {
            if (point != null)
            {
                point.GlowUp();
            }

        }
    }

    private void ClearValidPoints()
    {
        foreach (SpawnPoint point in _validPoints)
        {
            if (point != null)
            {
                point.StopGlowing();
            }
        }

        _validPoints.Clear();
    }

    private void ReturnToStartPosition()
    {
        _transform.position = _startPosition;
    }
}