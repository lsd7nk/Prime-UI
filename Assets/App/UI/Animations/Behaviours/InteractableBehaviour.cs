using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class InteractableBehaviour : AnimationBehaviour
    {
        [SerializeField] private PunchAnimationsContainer _punchAnimations;

        public InteractableBehaviour() : base(AnimationType.Punch) { }

        public override void Execute(Container animatedContainer, bool withoutAnimation = false,
            Action onStartCallback = null, Action onFinishCallback = null)
        {
            if (!withoutAnimation && _punchAnimations.IsEnabled)
            {
                ExecuteAsync(animatedContainer, onStartCallback, onFinishCallback).Forget();
            }
            else
            {
                _onStartEvent.Invoke();
                onStartCallback?.Invoke();

                _onFinishEvent.Invoke();
                onFinishCallback?.Invoke();
            }
        }

        public override async UniTask ExecuteAsync(Container animatedContainer,
            Action onStartCallback = null, Action onFinishCallback = null)
        {
#pragma warning disable CS4014
            if (_punchAnimations.Move.IsEnabled)
            {
                animatedContainer.ResetPosition();
                Animator.MovePunch(animatedContainer.RectTransform, _punchAnimations.Move);
            }

            if (_punchAnimations.Rotate.IsEnabled)
            {
                animatedContainer.ResetRotation();
                Animator.RotatePunch(animatedContainer.RectTransform, _punchAnimations.Rotate);
            }

            if (_punchAnimations.Scale.IsEnabled)
            {
                animatedContainer.ResetScale();
                Animator.ScalePunch(animatedContainer.RectTransform, _punchAnimations.Scale);
            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(_punchAnimations.TotalDuration * AnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));
        }

        protected override void Reset(AnimationType animationType)
        {
            _punchAnimations = new PunchAnimationsContainer();

            base.Reset(animationType);
        }
    }
}
