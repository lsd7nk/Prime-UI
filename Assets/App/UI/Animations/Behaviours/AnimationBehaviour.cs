using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public abstract class AnimationBehaviour
    {
        [SerializeField] protected UnityEvent _onStartEvent;
        [SerializeField] protected UnityEvent _onFinishEvent;

        public AnimationBehaviour(AnimationType animationType)
        {
            Reset(animationType);
        }

        public abstract void Execute(Container animatedContainer, bool withoutAnimation = false,
            Action onStartCallback = null, Action onFinishCallback = null);

        public abstract UniTask ExecuteAsync(Container animatedContainer,
            Action onStartCallback = null, Action onFinishCallback = null);

        public virtual void ExecuteInstantly(Container animatedContainer) { }

        protected virtual void Reset(AnimationType animationType)
        {
            _onStartEvent?.RemoveAllListeners();
            _onFinishEvent?.RemoveAllListeners();
        }
    }
}