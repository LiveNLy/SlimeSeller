using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelCompletedImages : MonoBehaviour
    {
        [SerializeField] private LevelInfo _info;

        [Header("Настройки изображений")]
        [SerializeField] private Sprite _image1Sprite;
        [SerializeField] private Sprite _image2Sprite;
        [SerializeField] private Sprite _image3Sprite;

        [Header("Цвета изображений")]
        [SerializeField] private Color _image1Color = Color.white;
        [SerializeField] private Color _image2Color = Color.white;
        [SerializeField] private Color _image3Color = Color.white;

        [Header("Размеры изображений")]
        [SerializeField] private Vector2 _image1Size = new Vector2(80, 80);
        [SerializeField] private Vector2 _image2Size = new Vector2(90, 90);
        [SerializeField] private Vector2 _image3Size = new Vector2(100, 100);

        [Header("Позиции относительно кнопки")]
        [SerializeField] private Vector2 _image1Position = new Vector2(-98, 46);
        [SerializeField] private Vector2 _image2Position = new Vector2(103, 42);
        [SerializeField] private Vector2 _image3Position = new Vector2(4, 20);

        private void Start()
        {
            _info = GetComponent<LevelInfo>();
            CreateButtonWithImages();
        }

        public void CreateButtonWithImages()
        {
            GameObject buttonObject = gameObject;
            Button button = buttonObject.GetComponent<Button>();

            if (button == null)
                button = buttonObject.AddComponent<Button>();

            Image buttonImage = buttonObject.GetComponent<Image>();

            if (buttonImage == null)
                buttonImage = buttonObject.AddComponent<Image>();

            CreateChildImage("Icon1", _image1Sprite, _image1Color, _image1Size, _image1Position);
            CreateChildImage("Icon2", _image2Sprite, _image2Color, _image2Size, _image2Position);
            CreateChildImage("Icon3", _image3Sprite, _image3Color, _image3Size, _image3Position);

            _info.SetImage();
        }

        private void CreateChildImage(string name, Sprite sprite, Color color, Vector2 size, Vector2 position)
        {
            GameObject imageObject = new GameObject(name);
            imageObject.transform.SetParent(transform);
            Image image = imageObject.AddComponent<Image>();
            image.sprite = sprite;
            image.color = color;
            RectTransform rectTransform = imageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            rectTransform.anchoredPosition = position;
            rectTransform.anchorMin = new Vector2(0.5f, 0f);
            rectTransform.anchorMax = new Vector2(0.5f, 0f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);

            imageObject.SetActive(false);
        }
    }
}