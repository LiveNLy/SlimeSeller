using UnityEngine;


public class PlusTimer : Effect
{
    private float _effectPower = 10;
    private ITimer _timer;

    public override void ApplyEffect()
    {
        Debug.Log(_timer);
        _timer.DoConverce(_effectPower);
    }

    public override void SetTool(Tool timer)
    {
        _timer = (ITimer)timer;
    }
}
