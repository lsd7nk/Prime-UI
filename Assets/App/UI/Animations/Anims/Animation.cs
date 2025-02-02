using UnityEngine;
using PrimeTween;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public abstract class Animation<T> : Animation where T : struct
    {
        [field: SerializeField] public T From { get; private set; }
        [field: SerializeField] public T To { get; private set; }
        [field: SerializeField] public T By { get; private set; }

        protected Animation(AnimationType animationType)
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
    public abstract class Animation
    {
        public float TotalDuration
        {
            get
            {
                return StartDelay + Duration;
            }
        }

        public AnimationType AnimationType { get; private set; } = AnimationType.None;

        [field: SerializeField] public bool IsEnabled { get; private set; }
        [field: SerializeField] public bool UseCustomFromAndTo { get; private set; }

        [field: SerializeField] public float StartDelay { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }

        [field: SerializeField] public int Frequency { get; private set; }
        [field: SerializeField] public float AsymmetryFactor { get; private set; }
        [field: SerializeField] public int NumberOfCycles { get; private set; }

        [field: SerializeField] public CycleMode CycleMode { get; private set; }
        [field: SerializeField] public EaseType EaseType { get; private set; }

        [field: SerializeField] public Ease Ease { get; private set; }
        [field: SerializeField] public AnimationCurve AnimationCurve { get; private set; }

        public virtual void Reset(AnimationType animationType)
        {
            AnimationType = animationType;

            IsEnabled = AnimatorConstants.IS_ENABLED;
            UseCustomFromAndTo = AnimatorConstants.USE_CUSTOM_FROM_AND_TO;

            StartDelay = AnimatorConstants.START_DELAY;
            Duration = AnimatorConstants.DURATION;

            Frequency = AnimatorConstants.FREQUENCY;
            AsymmetryFactor = AnimatorConstants.ASYMMETRY_FACTOR;
            NumberOfCycles = AnimatorConstants.NUMBER_OF_LOOPS;

            CycleMode = AnimatorConstants.CYCLE_MODE;
            EaseType = AnimatorConstants.EASY_TYPE;

            Ease = AnimatorConstants.EASE;
            AnimationCurve = new AnimationCurve();
        }

        public Easing GetEasing()
        {
            return EaseType switch
            {
                EaseType.Ease => Ease,
                EaseType.AnimationCurve => AnimationCurve,
                _ => throw new NotImplementedException()
            };
        }
    }
}