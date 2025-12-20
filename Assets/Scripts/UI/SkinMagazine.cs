using BasketsStuff;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace UI
{
    public class SkinMagazine : MonoBehaviour
    {
        [SerializeField] private List<SkinButton> _skinButtons;
        [SerializeField] private Basket _basketPrefab;
        [SerializeField] private Stars _stars;

        private void Start()
        {
            SubscribeOnButtonClick();
        }

        private void OnEnable()
        {
            foreach (var skinButton in _skinButtons)
            {
                if (skinButton.Skin.name == YG2.saves.SlimeSpriteName)
                {
                    skinButton.TurnOnIndicator();
                }
                else
                {
                    skinButton.TurnOffIndicator();
                }
            }

            SubscribeOnButtonClick();
        }

        private void OnDisable()
        {
            UnSubscribeOnButtonClick();
        }

        private void SubscribeOnButtonClick()
        {
            foreach (var skinButton in _skinButtons)
            {
                skinButton.OnButtonClick += ChangeSkin;
            }
        }

        private void UnSubscribeOnButtonClick()
        {
            foreach (var skinButton in _skinButtons)
            {
                skinButton.OnButtonClick -= ChangeSkin;
            }
        }

        private void RemoveIndicators()
        {
            foreach (var skinButton in _skinButtons)
            {
                skinButton.TurnOffIndicator();
            }
        }

        private void ChangeSkin(SkinButton skinButton, int price, string title)
        {
            if (_stars.StarsNumber >= price)
            {
                RemoveIndicators();
                _stars.RemoveCoins(price);
                _basketPrefab.SetSlimeSprite(skinButton.Skin);
                YG2.saves.ChangePriceForSkin(title);
                YG2.saves.SlimeSpriteName = title;
                YG2.SaveProgress();
                YG2.InterstitialAdvShow();
                skinButton.SetPrice(title);
                skinButton.TurnOnIndicator();
            }
        }
    }
}