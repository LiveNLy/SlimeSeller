using UnityEngine;
using Timescale;
using YG;

namespace UI
{
    public class InGamePause : MonoBehaviour
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private GameInitializer _controller;
        [SerializeField] private InGamePause _gamePause;
        [SerializeField] private GameCanvas _button;
        [SerializeField] private Canvas _backgroundCanvas;
        [SerializeField] private RestarWindow _restartWindow;
        [SerializeField] private AudioSource _mainmenuAmbient;
        [SerializeField] private AudioSource _scoreModeAmbient;
        [SerializeField] private TimescaleChanger _timescaler;

        public void BackToGame()
        {
            if (!_restartWindow.gameObject.activeSelf)
            {
                _timescaler.NormalizeTimescale();
            }

            _button.gameObject.SetActive(true);
            _gamePause.gameObject.SetActive(false);
        }

        public void BackToMainMenu()
        {
            _timescaler.NormalizeTimescale();
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
}