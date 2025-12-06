using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlusCoins : Tool
{
    [SerializeField] private TextMeshProUGUI _textStars;
    [SerializeField] private TextMeshProUGUI _textScore;
    [SerializeField] private Stars _stars;

    private int _savedCoins;

    public void AddCoins(int coins)
    {
        _savedCoins += coins;
    }

    public void WritePlusCoinsNumber(int scoreNumber)
    {
        _textStars.text = "+" + _savedCoins;
        _textScore.text = $"{scoreNumber}";
        _stars.AddStars(_savedCoins);
    }

    public void ResetSavedCoinsNumber()
    {
        _savedCoins = 0;
    }
}