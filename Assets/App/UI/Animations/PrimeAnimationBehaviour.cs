using UnityEngine.Events;
using UnityEngine;
using System;

namespace App.UI.Animations
{
    [Serializable]
    public sealed class PrimeAnimationBehaviour
    {
        [field: SerializeField] public PrimeAnimation Animation { get; private set; }

        [field: SerializeField] public UnityEvent OnStartEvent { get; private set; }
        [field: SerializeField] public UnityEvent OnFinishEvent { get; private set; }

        [field: SerializeField] public bool WithoutAnimation { get; private set; }

        public PrimeAnimationBehaviour(AnimationType animationType)
        {
            Reset(animationType);
        }

        public void Reset(AnimationType animationType)
        {
            Animation = new PrimeAnimation(animationType);

            OnStartEvent = new UnityEvent();
            OnFinishEvent = new UnityEvent();
        }
    }
}