using UnityEngine;
using YG;

public class PauseInGameLevel : MonoBehaviour
{
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private PauseInGameLevel _gamePause;
    [SerializeField] private InGameButton _button;

    public void BackToGame()
    {
        Time.timeScale = 1;
        _button.gameObject.SetActive(true);
        _gamePause.gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        YG2.InterstitialAdvShow();
        _levelChanger.OnLevel();
    }
}