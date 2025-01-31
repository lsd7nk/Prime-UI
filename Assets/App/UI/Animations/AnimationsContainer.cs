using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class AnimationsContainer
    {
        public const float MAX_START_DELAY = 10000f;
        public const float MIN_TOTAL_DURATION = 0f;

        public bool IsEnabled
        {
            get
            {
                return AnimationType switch
                {
                    AnimationType.None => false,
                    AnimationType.Punch => Move.IsEnabled || Rotate.IsEnabled || Scale.IsEnabled,
                    _ => Move.IsEnabled || Rotate.IsEnabled || Scale.IsEnabled || Fade.IsEnabled
                };
            }
        }

        public float StartDelay
        {
            get
            {
                if (!IsEnabled)
                {
                    return 0;
                }

                return Mathf.Min(Move.IsEnabled ? Move.StartDelay : MAX_START_DELAY,
                                 Rotate.IsEnabled ? Rotate.StartDelay : MAX_START_DELAY,
                                 Scale.IsEnabled ? Scale.StartDelay : MAX_START_DELAY,
                                 Fade.IsEnabled ? Fade.StartDelay : MAX_START_DELAY);
            }
        }

        public float TotalDuration
        {
            get
            {
                if (!IsEnabled)
                {
                    return 0;
                }

                return Mathf.Max(Move.IsEnabled ? Move.TotalDuration : MIN_TOTAL_DURATION,
                                 Rotate.IsEnabled ? Rotate.TotalDuration : MIN_TOTAL_DURATION,
                                 Scale.IsEnabled ? Scale.TotalDuration : MIN_TOTAL_DURATION,
                                 Fade.IsEnabled ? Fade.TotalDuration : MIN_TOTAL_DURATION);
            }
        }

#if UNITY_EDITOR
        [field: ReadOnly]
#endif
        [field: SerializeField] public AnimationType AnimationType { get; private set; } = AnimationType.None;

        [field: SerializeField] public RotateAnimation Rotate { get; private set; }
        [field: SerializeField] public ScaleAnimation Scale { get; private set; }
        [field: SerializeField] public MoveAnimation Move { get; private set; }
        [field: SerializeField] public FadeAnimation Fade { get; private set; }

        public AnimationsContainer(AnimationType animationType)
        {
            Reset(animationType);
        }

        public void Reset(AnimationType animationType)
        {
            AnimationType = animationType;

            Rotate = new RotateAnimation(animationType);
            Scale = new ScaleAnimation(animationType);
            Move = new MoveAnimation(animationType);
            Fade = new FadeAnimation(animationType);
        }
    }
}