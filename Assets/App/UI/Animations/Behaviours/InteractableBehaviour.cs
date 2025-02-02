using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class InteractableBehaviour : AnimationBehaviour
    {
        [SerializeField] private AnimationsContainer _animations;

        public InteractableBehaviour(InteractableAnimationType animationType)
            : base(AnimationsUtils.GetAnimationType(animationType)) { }

        public override void Execute(Container animatedContainer, bool withoutAnimation = false,
            Action onStartCallback = null, Action onFinishCallback = null)
        {
            if (!withoutAnimation && _animations.IsEnabled)
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
            if (_animations.AnimationType == AnimationType.Punch)
            {
                if (_animations.Move.IsEnabled)
                {
                    animatedContainer.ResetPosition();
                    Animator.MovePunch(animatedContainer.RectTransform, _animations.Move);
                }

                if (_animations.Rotate.IsEnabled)
                {
                    animatedContainer.ResetRotation();
                    Animator.RotatePunch(animatedContainer.RectTransform, _animations.Rotate);
                }

                if (_animations.Scale.IsEnabled)
                {
                    animatedContainer.ResetScale();
                    Animator.ScalePunch(animatedContainer.RectTransform, _animations.Scale);
                }
            }
            else
            {

            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(_animations.TotalDuration * AnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));
        }

        protected override void Reset(AnimationType animationType)
        {
            _animations = new AnimationsContainer(animationType);

            base.Reset(animationType);
        }
    }
}
