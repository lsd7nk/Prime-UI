using UnityEngine.Events;
using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class AnimationBehaviour
    {
        [field: SerializeField] public AnimationsContainer Animations { get; private set; }

        [field: SerializeField] public UnityEvent OnStartEvent { get; private set; }
        [field: SerializeField] public UnityEvent OnFinishEvent { get; private set; }

        public AnimationBehaviour(AnimationType animationType)
        {
            Reset(animationType);
        }

        public void Reset(AnimationType animationType)
        {
            Animations = new AnimationsContainer(animationType);

            OnStartEvent = new UnityEvent();
            OnFinishEvent = new UnityEvent();
        }
    }
}