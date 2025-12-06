using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusPoints : Effect
{
    private Score _score;
    private int _massivePoints;

    public override void ApplyEffect()
    {
        _massivePoints = Random.Range(50, 80);
        _score.AddScore(_massivePoints);
    }

    public override void SetTool(Tool score)
    {
        _score = (Score)score;
    }
}
