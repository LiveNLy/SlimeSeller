using UnityEngine;

namespace UI
{
    public class MenuToMenu : MonoBehaviour
    {
        [SerializeField] private SideMenu _fromMenu;
        [SerializeField] private SideMenu _toMenu;

        public void MenuToMenuTransition()
        {
            _toMenu.gameObject.SetActive(true);
            _fromMenu.gameObject.SetActive(false);
        }
    }
}