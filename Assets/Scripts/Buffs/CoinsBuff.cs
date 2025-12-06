using UnityEngine;

public class CoinsBuff : Effect
{
    private PlusCoins _coins;
    private int _coinsToBeGiven;

    public override void ApplyEffect()
    {
        _coinsToBeGiven = Random.Range(10, 20);
        _coins.AddCoins(_coinsToBeGiven);
    }

    public override void SetTool(Tool coins)
    {
        _coins = (PlusCoins)coins;
    }
}
