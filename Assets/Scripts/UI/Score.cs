using Interfaces;
using TMPro;
using UnityEngine;
using YG;

namespace UI
{
    public class Score : MonoBehaviour, ITool
    {
        [SerializeField] private TextMeshProUGUI _textScore;

        private int _score;

        public int ScoreNumber => _score;

        private void Start()
        {
            RestartScore();
            ResetScore();
        }

        public void AddScore(int score)
        {
            _score += score;
            _textScore.text = _score.ToString();
        }

        public void ResetScore()
        {
            _score = 0;
            _textScore.text = _score.ToString();
        }

        public void RestartScore()
        {
            if (_score > YG2.saves.Record)
            {
                YG2.saves.Record = _score;
                YG2.SetLeaderboard("LeaderboardYG", YG2.saves.Record);
            }
        }

        public void ApplyEffect(int number)
        {
            AddScore(number);
        }
    }
}