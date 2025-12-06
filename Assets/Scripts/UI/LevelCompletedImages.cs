using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedImages : MonoBehaviour
{
    [SerializeField] private LevelInfo _info;

    [Header("Настройки изображений")]
    public Sprite image1Sprite;
    public Sprite image2Sprite;
    public Sprite image3Sprite;

    [Header("Цвета изображений")]
    public Color image1Color = Color.white;
    public Color image2Color = Color.white;
    public Color image3Color = Color.white;

    [Header("Размеры изображений")]
    public Vector2 image1Size = new Vector2(80, 80);
    public Vector2 image2Size = new Vector2(90, 90);
    public Vector2 image3Size = new Vector2(100, 100);

    [Header("Позиции относительно кнопки")]
    public Vector2 image1Position = new Vector2(-98, 46);
    public Vector2 image2Position = new Vector2(103, 42);
    public Vector2 image3Position = new Vector2(4, 20);

    void Start()
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

        CreateChildImage("Icon1", image1Sprite, image1Color, image1Size, image1Position);
        CreateChildImage("Icon2", image2Sprite, image2Color, image2Size, image2Position);
        CreateChildImage("Icon3", image3Sprite, image3Color, image3Size, image3Position);

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