using UnityEngine.EventSystems;
using Prime.UI.Animations;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace Prime.UI.Button
{
    [RequireComponent(typeof(Container), typeof(GraphicRaycaster))]
    public sealed class Button : AnimatedComponent, IButton
    {
        public event Action OnPointerClickEvent;
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;

        [Space(10), Header("Button")]
        [SerializeField] private InteractableBehaviour _pointerClickBehaviour;
        [SerializeField] private InteractableBehaviour _pointerDownBehaviour;
        [SerializeField] private InteractableBehaviour _pointerUpBehaviour;

        public void OnPointerClick(PointerEventData eventData)
        {
            _pointerClickBehaviour.Execute(_animatedContainer);
            OnPointerClickEvent?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pointerDownBehaviour.Execute(_animatedContainer);
            OnPointerDownEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pointerUpBehaviour.Execute(_animatedContainer);
            OnPointerUpEvent?.Invoke();
        }

        protected override void Reset()
        {
            base.Reset();

            _pointerClickBehaviour = new InteractableBehaviour();
            _pointerDownBehaviour = new InteractableBehaviour();
            _pointerUpBehaviour = new InteractableBehaviour();
        }
    }
}