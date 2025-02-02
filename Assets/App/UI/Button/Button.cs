using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace Prime.UI.Button
{
    [RequireComponent(typeof(Container))]
    public sealed class Button : AnimatedComponent, IButton
    {
        public event Action OnPointerClickEvent;
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnPointerClickEvent?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDownEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnPointerUpEvent?.Invoke();
        }
    }
}