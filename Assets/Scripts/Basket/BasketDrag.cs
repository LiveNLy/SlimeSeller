using UnityEngine;
using YG;

public class BasketDrag : MonoBehaviour
{
    [SerializeField] private float _zCorrecter = 1.3f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _yHight;
    [SerializeField] AudioSource _click;

    private Basket _draggedBasket;
    private bool _isDragging = false;
    private bool _isMobile;
    private Ray _ray;
    private float _maxDistance = 50;

    private void Start()
    {
        _isMobile = YG2.envir.isMobile;
    }

    private void Update()
    {
        if (!_isMobile)
        {
            ClickSlime();
        }
        else
        {
            TouchSlime();
        }
    }

    private void SetRay(Vector3 input)
    {
        _ray = Camera.allCameras[1].ScreenPointToRay(input);
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

    private void DragSlime()
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

    private void TouchSlime()
    {
        if (Input.touchCount > 0)
        {
            SetRay(Input.GetTouch(0).position);

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                FindBasketByRay();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                DragSlime();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                StopDrag();
            }
        }
    }

    private void ClickSlime()
    {
        SetRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            FindBasketByRay();
        }

        if (Input.GetMouseButton(0))
        {
            DragSlime();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDrag();
        }
    }
}