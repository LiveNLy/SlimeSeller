using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private Slime _slime;
    [SerializeField] private BasketMover _mover;
    [SerializeField] private PositionSetter _positionSetter;

    private bool _isBlocked = false;
    private bool _isMoving = false;

    public bool IsBlocked => _isBlocked;

    private void FixedUpdate()
    {
        if (!_isMoving && _slime != null)
        {
            Vector3 oppositeDirection = transform.position - Camera.allCameras[1].transform.position;
            transform.rotation = Quaternion.LookRotation(oppositeDirection);
        }
    }

    public void Block()
    {
        _isBlocked = true;
    }

    public void SetSlimeSprite(Sprite newSprite)
    {
        if (_slime != null)
        {
            _slime.ChangeSkin(newSprite);
        }
    }

    public void Move(Vector3 direction)
    {
        if (_mover != null)
        {
            _mover.Move(direction);
            _isMoving = true;
        }
    }

    public Slime GetSlime()
    {
        return _slime;
    }

    public void SetPosition(float zCorrecter)
    {
        if (_positionSetter != null)
        {
            _positionSetter.SetPosition(zCorrecter, _slime, _mover);
            _isMoving = false;
        }
    }

    public void GetValidPoints()
    {
        if (_positionSetter != null)
            _positionSetter.GetValidPoints();
    }

    public void UnfreezePosition()
    {
        if (_positionSetter != null)
            _positionSetter.UnfreezePosition();
    }

    public void RememberFirstPosition()
    {
        if (_positionSetter != null)
            _positionSetter.RememberFirstPosition();
    }

    public void GlowPoints()
    {
        if (_positionSetter != null)
            _positionSetter.GlowPoints();
    }

    public void MakeMoveble()
    {
        _mover = gameObject.AddComponent<BasketMover>();
        _positionSetter = gameObject.AddComponent<PositionSetter>();
        _mover.SetStandartValues();
    }
}