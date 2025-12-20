using UnityEngine;

namespace UI
{
    public class RestarWindow : MonoBehaviour
    {
        [SerializeField] private OnLevelWin _onLevelWin;

        public void SetStatsWindow()
        {
            _onLevelWin = GetComponent<OnLevelWin>();
        }

        public void SetStats()
        {
            _onLevelWin.SetStats();
        }
    }
}