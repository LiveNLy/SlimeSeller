using System.Collections.Generic;
using UnityEngine;
using YG;
using System.Linq;
using UnityEngine.UI;

public class LanguageSwitch : MonoBehaviour
{
    [SerializeField] private Sprite _rus;
    [SerializeField] private Sprite _eng;
    [SerializeField] private Sprite _tr;
    [SerializeField] private Button _button;

    private Dictionary<int, string> _languages = new Dictionary<int, string>();
    private int _currentLanguage = 1;

    private void Awake()
    {
        Debug.Log(YG2.lang);

        _languages.Add(1, "ru");
        _languages.Add(2, "en");
        _languages.Add(3, "tr");
    }

    private void OnEnable()
    {
        SetStartLang();
    }

    private void Update()
    {
        switch (_currentLanguage)
        {
            case 1:
                _button.image.sprite = _rus;
                break;
            case 2:
                _button.image.sprite = _eng;
                break;
            case 3:
                _button.image.sprite = _tr;
                break;
        }
    }

    private void SetStartLang()
    {
        _currentLanguage = _languages.FirstOrDefault(x => x.Value == YG2.lang).Key;
    }

    public void SwitchLang()
    {
        if (_currentLanguage != 3)
        {
            _currentLanguage++;
   
        }
        else
        {
            _currentLanguage = 1;
   
        }

        YG2.SwitchLanguage(_languages.GetValueOrDefault(_currentLanguage));
    }
}