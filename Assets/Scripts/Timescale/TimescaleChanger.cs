using UnityEngine;

namespace Timescale
{
    public class TimescaleChanger : MonoBehaviour
    {
        private int _normalTimescale = 1;
        private int _stop = 0;

        public void NormalizeTimescale()
        {
            Time.timeScale = _normalTimescale;
        }

        public void StopTimescale()
        {
            Time.timeScale = _stop;
        }
    }
}