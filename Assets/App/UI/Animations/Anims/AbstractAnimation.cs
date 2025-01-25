using UnityEngine;
using PrimeTween;
using System;

namespace App.UI.Animations
{
    [Serializable]
    public abstract class AbstractAnimation<T> : AbstractAnimation where T : struct
    {
        [field: SerializeField] public T From { get; private set; }
        [field: SerializeField] public T To { get; private set; }
        [field: SerializeField] public T By { get; private set; }

        protected AbstractAnimation(AnimationType animationType)
        {
            Reset(animationType);
        }

        public override void Reset(AnimationType animationType)
        {
            base.Reset(animationType);

            From = default;
            To = default;
            By = default;
        }
    }

    [Serializable]
    public abstract class AbstractAnimation
    {
        public float TotalDuration
        {
            get
            {
                return StartDelay + Duration;
            }
        }

        [field: SerializeField] public AnimationType AnimationType { get; private set; } = AnimationType.None;

        [field: SerializeField] public bool IsEnabled { get; private set; }
        [field: SerializeField] public bool UseCustomFromAndTo { get; private set; }

        [field: SerializeField] public float StartDelay { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }

        [field: SerializeField] public int Vibrato { get; private set; }
        [field: SerializeField] public float Elasticity { get; private set; }
        [field: SerializeField] public int NumberOfCycles { get; private set; }

        [field: SerializeField] public CycleMode CycleMode { get; private set; }
        [field: SerializeField] public EaseType EaseType { get; private set; }

        [field: SerializeField] public Ease Ease { get; private set; }
        [field: SerializeField] public AnimationCurve AnimationCurve { get; private set; }

        public virtual void Reset(AnimationType animationType)
        {
            AnimationType = animationType;

            IsEnabled = PrimeAnimatorConstants.IS_ENABLED;
            UseCustomFromAndTo = PrimeAnimatorConstants.USE_CUSTOM_FROM_AND_TO;

            StartDelay = PrimeAnimatorConstants.START_DELAY;
            Duration = PrimeAnimatorConstants.DURATION;

            Vibrato = PrimeAnimatorConstants.VIBRATO;
            Elasticity = PrimeAnimatorConstants.ELASTICITY;
            NumberOfCycles = PrimeAnimatorConstants.NUMBER_OF_LOOPS;

            CycleMode = PrimeAnimatorConstants.CYCLE_MODE;
            EaseType = PrimeAnimatorConstants.EASY_TYPE;

            Ease = PrimeAnimatorConstants.EASE;
            AnimationCurve = new AnimationCurve();
        }
    }
}