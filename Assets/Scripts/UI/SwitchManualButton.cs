using UnityEngine;

namespace UI
{
    public class SwitchManualButton : MonoBehaviour
    {
        [SerializeField] private ManualWindow _slide;
        [SerializeField] private ManualWindow _nextSlide;
        [SerializeField] private ManualWindow _previousSlide;

        public void SwitchNextSlide()
        {
            _slide.gameObject.SetActive(false);
            _nextSlide.gameObject.SetActive(true);
        }

        public void SwitchPreviousSlide()
        {
            _slide.gameObject.SetActive(false);
            _previousSlide.gameObject.SetActive(true);
        }
    }
}