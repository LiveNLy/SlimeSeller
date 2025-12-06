using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] private Sprite _skin;
    [SerializeField] private Basket _basketPrefab;
    [SerializeField] private Stars _stars;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _title;
    [SerializeField] private Image _indicator;

    private int _price;

    private void Start()
    {
        _price = YG2.saves.SetPriceForSkin(_title);

        if (_price == 0)
        {
            _text.gameObject.SetActive(false);
        }
        else
        {
            _text.text = _price.ToString();
        }
    }

    private void OnEnable()
    {
        if (_skin.name == YG2.saves.SlimeSpriteName)
        {
            _indicator.gameObject.SetActive(true);
        }
        else
        {
            _indicator.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (_skin.name == YG2.saves.SlimeSpriteName)
        {
            _indicator.gameObject.SetActive(true);
        }
        else
        {
            _indicator.gameObject.SetActive(false);
        }
    }

    public void ChangeSlime()
    {
        if (_stars.StarsNumber >= _price)
        {
            _stars.RemoveCoins(_price);
            _basketPrefab.SetSlimeSprite(_skin);
            YG2.saves.ChangePriceForSkin(_title);
            YG2.saves.SlimeSpriteName = _title;
            YG2.SaveProgress();
            YG2.InterstitialAdvShow();
            _price = YG2.saves.SetPriceForSkin(_title);
            _text.gameObject.SetActive(false);
            _indicator.gameObject.SetActive(true);
        }
    }
}