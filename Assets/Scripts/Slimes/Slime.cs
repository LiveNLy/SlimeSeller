using UnityEngine;

namespace Slimes
{
    public class Slime : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _effectSprite;
        [SerializeField] private SpriteRenderer _renderer;

        private int _minRandomScorePoints = 10;
        private int _maxRandomScorePoints = 20;
        private int _minRandomStars = 1;
        private int _maxRandomStars = 5;
        private int _scorePoints;
        private int _stars;

        public Color SlimeColor => _renderer.material.color;
        public int ScorePoints => _scorePoints;
        public int Stars => _stars;

        private void Awake()
        {
            _scorePoints = Random.Range(_minRandomScorePoints, _maxRandomScorePoints);
            _stars = Random.Range(_minRandomStars, _maxRandomStars);
        }

        public Sprite GetSkin()
        {
            return _renderer.sprite;
        }

        public Color GetColor()
        {
            return _renderer.material.color;
        }

        public void ChangeSkin(Sprite sprite)
        {
            _renderer.sprite = sprite;
        }
    }
}