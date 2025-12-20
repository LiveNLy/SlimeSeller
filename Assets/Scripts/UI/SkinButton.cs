using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI
{
    public class SkinButton : MonoBehaviour
    {
        [SerializeField] private Sprite _skin;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private string _title;
        [SerializeField] private Image _indicator;
        [SerializeField] private Button _button;

        private int _price;

        public event Action<SkinButton, int, string> OnButtonClick;

        public Sprite Skin => _skin;
        public string Title => _title;

        private void Start()
        {
            _text = GetComponentInParent<ManualWindow>().GetComponentInChildren<TextMeshProUGUI>();
            SetPrice(_title);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ChangeSkin);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ChangeSkin);
        }

        public void SetPrice(string title)
        {
            _price = YG2.saves.SetPriceForSkin(title);

            if (_price == 0)
            {
                _text.gameObject.SetActive(false);
            }
            else
            {
                _text.text = _price.ToString();
            }
        }

        public void TurnOnIndicator()
        {
            _indicator.gameObject.SetActive(true);
        }

        public void TurnOffIndicator()
        {
            _indicator.gameObject.SetActive(false);
        }

        private void ChangeSkin()
        {
            OnButtonClick?.Invoke(this, _price, _title);
        }
    }
}