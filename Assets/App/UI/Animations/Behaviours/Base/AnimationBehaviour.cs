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

        protected virtual void Reset(AnimationType animationType)
        {
            _onStartEvent?.RemoveAllListeners();
            _onFinishEvent?.RemoveAllListeners();
        }
    }
}