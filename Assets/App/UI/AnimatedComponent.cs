using Cysharp.Threading.Tasks;
using Prime.UI.Animations;
using UnityEngine;
using System;

namespace Prime.UI
{
    [DisallowMultipleComponent]
    public abstract class AnimatedComponent : MonoBehaviour
    {
        public event Action OnShowStartEvent;
        public event Action OnShowFinishEvent;

        public event Action OnHideStartEvent;
        public event Action OnHideFinishEvent;

        [SerializeField] protected Container _animatedContainer;

        [Space(10)]
        [SerializeField] private NotInteractableBehaviour _showBehaviour;
        [SerializeField] private NotInteractableBehaviour _hideBehaviour;

        public AnimatedComponent()
        {
            Reset();
        }

        public void Show(bool withoutAnimation = false)
        {
            _showBehaviour.Execute(_animatedContainer, withoutAnimation, OnShowStartEvent, OnShowFinishEvent);
        }

        public void Hide(bool withoutAnimation = false)
        {
            _hideBehaviour.Execute(_animatedContainer, withoutAnimation, OnHideStartEvent, OnHideFinishEvent);
        }

        public async UniTask ShowAsync()
        {
            await _showBehaviour.ExecuteAsync(_animatedContainer);
        }

        public async virtual UniTask HideAsync()
        {
            await _hideBehaviour.ExecuteAsync(_animatedContainer);
        }

        public void ShowInstantly()
        {
            _showBehaviour.ExecuteInstantly(_animatedContainer);
        }

        public virtual void HideInstantly()
        {
            _hideBehaviour.ExecuteInstantly(_animatedContainer);
        }

        protected virtual void Reset()
        {
            _showBehaviour = new NotInteractableBehaviour(NotInteractableAnimationType.Show);
            _hideBehaviour = new NotInteractableBehaviour(NotInteractableAnimationType.Hide);
        }
    }
}