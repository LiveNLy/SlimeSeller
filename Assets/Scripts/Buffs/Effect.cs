using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Effect : MonoBehaviour, IPointerClickHandler
{
    public abstract void ApplyEffect();

    public void OnPointerClick(PointerEventData eventData)
    {
        ApplyEffect();
        gameObject.SetActive(false);
    }

    public abstract void SetTool(Tool tool);
}