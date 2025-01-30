using Cysharp.Threading.Tasks;
using Prime.UI.Animations;
using UnityEngine;
using System;

namespace Prime.UI
{
    [DisallowMultipleComponent]
    public abstract class AnimatedComponent : BaseComponent
    {
        public event Action OnShowStartEvent;
        public event Action OnShowFinishEvent;

        public event Action OnHideStartEvent;
        public event Action OnHideFinishEvent;

        [SerializeField] private AnimationBehaviour _showBehaviour;
        [SerializeField] private AnimationBehaviour _hideBehaviour;

        [SerializeField] private Container _animatedContainer;

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

        protected void ShowInstantly()
        {
            _showBehaviour.ExecuteInstantly(_animatedContainer);
        }

        protected virtual void HideInstantly()
        {
            _hideBehaviour.ExecuteInstantly(_animatedContainer);
        }

        protected override void Reset()
        {
            base.Reset();

            _showBehaviour = new AnimationBehaviour(AnimationType.Show);
            _hideBehaviour = new AnimationBehaviour(AnimationType.Hide);
        }
    }
}