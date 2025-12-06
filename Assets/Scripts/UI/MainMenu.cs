using UnityEngine;
using YG;
using YG.Insides;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameInitializer _game;
    [SerializeField] private ITimer _timer;
    [SerializeField] private InGamePause _gamePause;
    [SerializeField] private InGameButton _gameButton;
    [SerializeField] private MainMenu _menu;
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private Canvas _backgroundCanvas;
    [SerializeField] private Basket _basketPrefab;
    [SerializeField] private Sprite _standartSprite;
    [SerializeField] private SpriteManager _spriteManager;
    [SerializeField] private RestarWindow _restarWindow;
    [SerializeField] private AudioSource _mainmenuAmbient;
    [SerializeField] private AudioSource _scoreModeAmbient;

    private void Start()
    {
        _timer = _game.GetComponentInChildren<ITimer>();

        if (YG2.saves.IsFirstTimeEnter)
        {
            YG2.saves.FillDict();
            YG2.saves.IsFirstTimeEnter = false;
            _basketPrefab.SetSlimeSprite(_standartSprite);
            YG2.saves.SlimeSpriteName = "SlimeSprite";
            YG2.SaveProgress();
        }

        if (YG2.saves.SlimeSpriteName == null)
        {
            YG2.saves.SlimeSpriteName = "SlimeSprite";
        }

        _basketPrefab.SetSlimeSprite(_spriteManager.LoadSprite(YG2.saves.SlimeSpriteName));
    }

    public void OpenGame()
    {

        Time.timeScale = 1;
        _game.gameObject.SetActive(true);
        _scoreModeAmbient.gameObject.SetActive(true);
        _mainmenuAmbient.gameObject.SetActive(false);
        _backgroundCanvas.gameObject.SetActive(false);
        _gamePause.gameObject.SetActive(false);
        _gameButton.gameObject.SetActive(true);
        _timer.RestartTimer();
        _menu.gameObject.SetActive(false);
        _restarWindow.gameObject.SetActive(false);
        _game.Restart();
    }
}