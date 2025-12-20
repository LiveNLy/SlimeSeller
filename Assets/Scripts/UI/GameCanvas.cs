using Timescale;
using UnityEngine;

namespace UI
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private InGamePause _pause;
        [SerializeField] private GameCanvas _button;
        [SerializeField] private TimescaleChanger _timescaler;

        public void PauseClick()
        {
            _timescaler.StopTimescale();
            _pause.gameObject.SetActive(true);
            _button.gameObject.SetActive(false);
        }
    }
}