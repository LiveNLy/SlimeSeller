using UnityEngine;
using UnityEngine.UI;
using YG;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private Image _doneImage;
    [SerializeField] private Image _silverImage;
    [SerializeField] private Image _goldImage;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private Button _button;

    private int _levelNumber;
    private LevelChanger _changer;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        _changer = GetComponent<LevelChanger>();
        _levelNumber = _changer.NeededLevel;
    }

    private void OnEnable()
    {
        int previousLevel = _levelNumber - 2;

        if (previousLevel < 0)
        {
            previousLevel = 0;
        }

        if (YG2.saves.GetLevelInfo(previousLevel) || previousLevel == _levelNumber - 1)
        {
            _changer.SetIsEnabled(true);
            SetAlpha(1f);
            ChangePressedButtonParam(Color.gray);
        }
        else if (!YG2.saves.GetLevelInfo(previousLevel))
        {
            _changer.SetIsEnabled(false);
            SetAlpha(0.5f);
            ChangePressedButtonParam(Color.red);
        }
    }

    public void SetImage()
    {
        var images = GetComponentsInChildren<Image>(includeInactive: true);

        if (images.Length > 1)
        {
            _doneImage = images[1];
            _silverImage = images[2];
            _goldImage = images[3];
        }

        if (YG2.saves.GetLevelInfo(_levelNumber - 1))
        {
            _doneImage.gameObject.SetActive(true);
        }

        if (YG2.saves.LevelsStats[_levelNumber - 1] == "silver")
        {
            _silverImage.gameObject.SetActive(true);
        }
        else if (YG2.saves.LevelsStats[_levelNumber - 1] == "gold")
        {
            _silverImage.gameObject.SetActive(true);
            _goldImage.gameObject.SetActive(true);
        }
    }

    private void ChangePressedButtonParam(Color color)
    {
        ColorBlock colorBlock = _button.colors;
        colorBlock.pressedColor = color;
        _button.colors = colorBlock;
    }

    public void SetAlpha(float alpha)
    {
        Color currentColor = _buttonImage.color;
        currentColor.a = Mathf.Clamp01(alpha);
        _buttonImage.color = currentColor;
    }
}