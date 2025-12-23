using Interfaces;
using System;
using UnityEngine;

public class TouchInput : IInput
{
    public event Action OnClickStarted;
    public event Action OnClickHeld;
    public event Action OnClickEnded;
    public event Action<Vector3> GetClickPosition;


    public void Update()
    {
        GetClickPosition?.Invoke(Input.mousePosition);

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                OnClickStarted?.Invoke();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                OnClickHeld?.Invoke();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                OnClickEnded?.Invoke();
            }
        }
    }
}