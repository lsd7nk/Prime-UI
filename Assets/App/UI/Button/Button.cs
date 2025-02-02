using UnityEngine.EventSystems;
using Prime.UI.Animations;
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

        [Space(10), Header("Button")]
        [SerializeField] private InteractableBehaviour _clickBehaviour;
        [SerializeField] private InteractableBehaviour _downBehaviour;
        [SerializeField] private InteractableBehaviour _upBehaviour;

        public Button()
        {
            Reset();
        }

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

        protected override void Reset()
        {
            base.Reset();

            _clickBehaviour = new InteractableBehaviour(InteractableAnimationType.Punch);
            _downBehaviour = new InteractableBehaviour(InteractableAnimationType.Punch);
            _upBehaviour = new InteractableBehaviour(InteractableAnimationType.Punch);
        }
    }
}