using BasketsStuff;
using Interfaces;
using UnityEngine;
using YG;

namespace Inputs
{
    public class BasketInteractor : MonoBehaviour
    {
        [SerializeField] private float _zCorrecter = 1.3f;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _yHight;
        [SerializeField] private AudioSource _click;

        private IInput _input;
        private Basket _draggedBasket;
        private bool _isDragging = false;
        private bool _isMobile;
        private Ray _ray;
        private float _maxDistance = 50;

        private void Start()
        {
            _isMobile = YG2.envir.isMobile;

            _input = (_isMobile) ? new TouchInput() : new MouseInput();

            _input.GetClickPosition += SetRay;
            _input.OnClickStarted += FindBasketByRay;
            _input.OnClickHeld += DragBasket;
            _input.OnClickEnded += StopDrag;
        }

        private void OnDisable()
        {
            _input.GetClickPosition -= SetRay;
            _input.OnClickStarted -= FindBasketByRay;
            _input.OnClickHeld -= DragBasket;
            _input.OnClickEnded -= StopDrag;
        }

        private void Update()
        {
            _input?.Update();
        }

        private void SetRay(Vector3 mousePosition)
        {
            _ray = Camera.allCameras[1].ScreenPointToRay(mousePosition);
        }

        private void FindBasketByRay()
        {
            if (Physics.Raycast(_ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent<Basket>(out Basket basket))
                {
                    PrepareBasket(basket);
                }
            }
        }

        private void PrepareBasket(Basket basket)
        {
            _click.Play();
            _draggedBasket = basket;
            _draggedBasket.UnfreezePosition();
            _draggedBasket.GetValidPoints();
            _draggedBasket.RememberFirstPosition();
            _draggedBasket.GlowPoints();
            _isDragging = true;
        }

        private void DragBasket()
        {
            if (Physics.Raycast(_ray, out RaycastHit hitInfo, _maxDistance, _layerMask) && _isDragging)
            {
                if (!hitInfo.collider.GetComponent<Basket>())
                {
                    Vector3 movePosition = new Vector3(hitInfo.point.x, hitInfo.point.y + _yHight, hitInfo.point.z - _zCorrecter);
                    _draggedBasket.Move(movePosition);
                }
            }
        }

        private void StopDrag()
        {
            if (_draggedBasket != null)
            {
                _isDragging = false;
                _draggedBasket.SetPosition(_zCorrecter);
                _draggedBasket = null;
            }
        }
    }
}