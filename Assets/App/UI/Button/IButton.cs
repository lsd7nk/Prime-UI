using UnityEngine.EventSystems;
using System;

namespace Prime.UI.Button
{
    public interface IButton : IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnPointerClickEvent;
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;
    }
}