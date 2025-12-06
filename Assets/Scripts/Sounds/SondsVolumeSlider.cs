using UnityEngine;
using UnityEngine.UI;

public class SondsVolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private MainSoundOption _musicOption;

    private void OnEnable()
    {
        ChangeVolumeBetweenWindow(_musicOption.MusicVolume);
        _volumeSlider.onValueChanged.AddListener(_musicOption.ChangeVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(_musicOption.ChangeVolume);
    }

    private void ChangeVolumeBetweenWindow(float currentVolume)
    {
        _volumeSlider.value = currentVolume;
    }
}
