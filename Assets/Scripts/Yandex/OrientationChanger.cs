using UnityEngine;

namespace ForYandex
{
    public class OrientationChanger : MonoBehaviour
    {
        [Header("Позиция камеры на экране Альбом")]
        [SerializeField] private float _xAlb;
        [SerializeField] private float _yAlb;
        [SerializeField] private float _wAlb;
        [SerializeField] private float _hAlb;

        [Space]
        [Header("Позиция камеры на экране Портрет")]
        [SerializeField] private float _xPort;
        [SerializeField] private float _yPort;
        [SerializeField] private float _wPort;
        [SerializeField] private float _hPort;

        [Space]
        [Header("Камера")]
        [SerializeField] private Camera _boardCamera;

        private void FixedUpdate()
        {
            if (Screen.orientation == ScreenOrientation.Portrait)
            {
                Rect squareViewport = new Rect(_xPort, _yPort, _wPort, _hPort);
                _boardCamera.rect = squareViewport;
            }
            else
            {
                Rect squareViewport = new Rect(_xAlb, _yAlb, _wAlb, _hAlb);
                _boardCamera.rect = squareViewport;
            }
        }
    }
}