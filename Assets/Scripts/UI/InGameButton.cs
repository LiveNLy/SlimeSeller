using UnityEngine;

public class InGameButton : MonoBehaviour
{
    [SerializeField] private InGamePause _pause;
    [SerializeField] private InGameButton _button;

    public void PauseClick()
    {
        Time.timeScale = 0;
        _pause.gameObject.SetActive(true);
        _button.gameObject.SetActive(false);
    }
}