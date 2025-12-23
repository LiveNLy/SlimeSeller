using Spawners;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TaskVisualizer : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private CustomerSpawner _customerSpawner;

        public Color ImageColor => _image.color;

        public void SetWantedColor(Color color)
        {
            _image.color = color;
        }
    }
}