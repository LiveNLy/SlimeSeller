using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1f;

    private float _currentAlpha;
    private float _targetAlpha = 1f;
    private bool _isFading = false;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (_isFading)
        {
            _currentAlpha = Mathf.MoveTowards(_currentAlpha, _targetAlpha, Time.unscaledDeltaTime / fadeTime);
            _canvasGroup.alpha = _currentAlpha;

            if (Mathf.Approximately(_currentAlpha, _targetAlpha))
            {
                _isFading = false;
                StartFadeOut();
            }
        }
    }

    public void StartFadeIn()
    {
        _targetAlpha = 1f;
        _currentAlpha = _canvasGroup.alpha;
        _isFading = true;
    }

    public void StartFadeOut()
    {
        _targetAlpha = 0f;
        _currentAlpha = _canvasGroup.alpha;
        _isFading = true;
    }
}