using UnityEngine;
using YG;

public class InGamePause : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameInitializer _controller;
    [SerializeField] private InGamePause _gamePause;
    [SerializeField] private InGameButton _button;
    [SerializeField] private Canvas _backgroundCanvas;
    [SerializeField] private RestarWindow _restartWindow;
    [SerializeField] private AudioSource _mainmenuAmbient;
    [SerializeField] private AudioSource _scoreModeAmbient;

    public void BackToGame()
    {
        if (!_restartWindow.gameObject.activeSelf)
        {
            Time.timeScale = 1;
        }

        _button.gameObject.SetActive(true);
        _gamePause.gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        YG2.InterstitialAdvShow();
        _backgroundCanvas.gameObject.SetActive(true);
        _mainMenu.gameObject.SetActive(true);

        if (_scoreModeAmbient != null && _mainmenuAmbient != null)
        {
            _scoreModeAmbient.gameObject.SetActive(false);
            _mainmenuAmbient.gameObject.SetActive(true);
        }

        _controller.gameObject.SetActive(false);
    }
}