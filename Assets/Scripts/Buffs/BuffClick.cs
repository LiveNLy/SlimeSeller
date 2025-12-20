using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Buffs
{
    public abstract class BuffClick : MonoBehaviour, IPointerClickHandler
    {
        public abstract void ApplyEffect();

        public void OnPointerClick(PointerEventData eventData)
        {
            ApplyEffect();
            gameObject.SetActive(false);
        }

        public abstract void SetTool(ITool tool);
    }
}