using UnityEngine;
using UnityEngine.Audio;
using YG;

namespace Sounds
{
    public class MainSoundOption : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mixer;
        [SerializeField] private string _musicName;

        private float _numberForCorrection = 20;
        private float _musicVolume;

        public float MusicVolume => _musicVolume;
        public float NumberForCorrection => _numberForCorrection;

        private void Start()
        {
            if (_musicName == "Other")
            {
                ChangeVolume(YG2.saves.MainVolume);
            }
            else if (_musicName == "Music")
            {
                ChangeVolume(YG2.saves.MusicVolume);
            }
        }

        public void ChangeVolume(float musicVolume)
        {
            _mixer.audioMixer.SetFloat(_musicName, Mathf.Log10(musicVolume) * _numberForCorrection);

            if (musicVolume == 0)
            {
                _mixer.audioMixer.SetFloat(_musicName, -80);
            }

            _musicVolume = musicVolume;

            if (_musicName == "Other")
            {
                YG2.saves.ChangeSoundVolume(_musicVolume);
            }
            else if (_musicName == "Music")
            {
                YG2.saves.ChangeMusicVolume(_musicVolume);
            }

            YG2.SaveProgress();
        }
    }
}