using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        public int Record;
        public int Stars;
        public string SlimeSpriteName;
        public int PriceForBogo = 200;
        public int PriceForViking = 500;
        public int PriceForManiac = 800;
        public int PriceForKing = 1200;
        public float MusicVolume = 1;
        public float MainVolume = 1;
        public bool IsFirstTimeEnter = true;
        public bool[] LevelsInfo = new bool[30];
        public string[] LevelsStats = new string[30];

        public bool GetLevelInfo(int levelNumber)
        {
            return LevelsInfo[levelNumber];
        }

        public void LevelDone(int levelNumber)
        {
            LevelsInfo[levelNumber] = true;
        }

        public void FillDict()
        {
            for (int i = 0; i < 30; i++)
            {
                LevelsInfo[i] = false;
            }

            for (int i = 0; i < 30; i++)
            {
                LevelsStats[i] = "none";
            }
        }

        public void SetStars()
        {
            Stars = 5000;
        }

        public void ChangeMusicVolume(float volume)
        {
            MusicVolume = volume;
        }

        public void ChangeSoundVolume(float volume)
        {
            MainVolume = volume;
        }

        public int SetPriceForSkin(string skinName)
        {
            switch (skinName)
            {
                case "SlimeBogo":
                    return PriceForBogo;
                case "SlimeViking":
                    return PriceForViking;
                case "SlimeEvil":
                    return PriceForManiac;
                case "SlimeKing":
                    return PriceForKing;
            }

            return 0;
        }

        public void ChangePriceForSkin(string skinName)
        {
            switch (skinName)
            {
                case "SlimeBogo":
                    PriceForBogo = 0;
                    break;
                case "SlimeViking":
                    PriceForViking = 0;
                    break;
                case "SlimeEvil":
                    PriceForManiac = 0;
                    break;
                case "SlimeKing":
                    PriceForKing = 0;
                    break;
            }
        }
    }
}