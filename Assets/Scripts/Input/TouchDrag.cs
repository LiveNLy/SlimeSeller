using Interfaces;
using UnityEngine;

public class TouchDrag : IInput
{
    public bool IsClickStarted()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            return true;
        }

        return false;
    }

    public bool IsClickHeld()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            return true;
        }

        return false;
    }

    public bool IsClickEnded()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
        {

            return true;
        }

        return false;
    }

    public Vector3 GetClickPosition()
    {
        return Input.GetTouch(0).position;
    }

    public bool HasClickInput()
    {
        return Input.touchCount > 0;
    }
}