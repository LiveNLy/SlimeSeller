using TMPro;
using UnityEngine;
using YG;

namespace UI
{
    public class Stars : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textStars;

        public int StarsNumber => YG2.saves.Stars;

        private void FixedUpdate()
        {
            if (YG2.saves.Stars > 5000)
            {
                YG2.saves.SetStars();
            }

            _textStars.text = YG2.saves.Stars.ToString();
        }

        public void AddStars(int stars)
        {
            YG2.saves.Stars += stars;
            _textStars.text = YG2.saves.Stars.ToString();
        }

        public void RemoveCoins(int star)
        {
            YG2.saves.Stars -= star;
            _textStars.text = YG2.saves.Stars.ToString();
        }
    }
}