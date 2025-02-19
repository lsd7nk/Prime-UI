using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class NotInteractableBehaviour : AnimationBehaviour,
        IAsyncExecutable, IInstantlyExecutable
    {
        protected override int MaxTweensCount => 4;

        [SerializeField] private AlphaAnimationsContainer _animations;

        public NotInteractableBehaviour(NotInteractableAnimationType animationType)
            : base(AnimationsUtils.GetAnimationType(animationType)) { }

        public void ExecuteInstantly(Container animatedContainer)
        {
            _onStartEvent.Invoke();

            var endMoveValue = AnimatorUtils.GetMoveTo(animatedContainer.RectTransform,
                _animations.Move, animatedContainer.StartPosition);

            animatedContainer.ResetPosition();
            Animator.InstantlyMove(animatedContainer.RectTransform, endMoveValue);

            var endRotateValue = AnimatorUtils.GetRotateTo(_animations.Rotate,
                animatedContainer.StartRotation);

            animatedContainer.ResetRotation();
            Animator.InstantlyRotate(animatedContainer.RectTransform, endRotateValue);

            var endScaleValue = AnimatorUtils.GetScaleTo(_animations.Scale,
                animatedContainer.StartScale);

            animatedContainer.ResetScale();
            Animator.InstantlyScale(animatedContainer.RectTransform, endScaleValue);

            var endFadeValue = AnimatorUtils.GetFadeTo(_animations.Fade,
                animatedContainer.StartAlpha);

            animatedContainer.ResetAlpha();
            Animator.InstantlyFade(animatedContainer.CanvasGroup, endFadeValue);

            _onFinishEvent.Invoke();
        }

        public async UniTask ExecuteAsync(Container animatedContainer, CancellationToken cancellationToken = default,
            Action onStartCallback = null, Action onFinishCallback = null)
        {
            StopAnimations();

            _onStartEvent.Invoke();
            onStartCallback?.Invoke();

#pragma warning disable CS4014
            if (_animations.Move.IsEnabled)
            {
                var startValue = AnimatorUtils.GetMoveFrom(animatedContainer.RectTransform,
                    _animations.Move, animatedContainer.StartPosition);
                var endValue = AnimatorUtils.GetMoveTo(animatedContainer.RectTransform,
                    _animations.Move, animatedContainer.StartPosition);

                AddAnimation(Animator.Move(animatedContainer.RectTransform, _animations.Move, startValue, endValue));
            }
            else
            {
                animatedContainer.ResetPosition();
            }

            if (_animations.Rotate.IsEnabled)
            {
                var startValue = AnimatorUtils.GetRotateFrom(_animations.Rotate,
                    animatedContainer.StartRotation);
                var endValue = AnimatorUtils.GetRotateTo(_animations.Rotate,
                    animatedContainer.StartRotation);

                AddAnimation(Animator.Rotate(animatedContainer.RectTransform, _animations.Rotate, startValue, endValue));
            }
            else
            {
                animatedContainer.ResetRotation();
            }

            if (_animations.Scale.IsEnabled)
            {
                var startValue = AnimatorUtils.GetScaleFrom(_animations.Scale,
                    animatedContainer.StartScale);
                var endValue = AnimatorUtils.GetScaleTo(_animations.Scale,
                    animatedContainer.StartScale);

                AddAnimation(Animator.Scale(animatedContainer.RectTransform, _animations.Scale, startValue, endValue));
            }
            else
            {
                animatedContainer.ResetScale();
            }

            if (_animations.Fade.IsEnabled)
            {
                var startValue = AnimatorUtils.GetFadeFrom(_animations.Fade,
                    animatedContainer.StartAlpha);
                var endValue = AnimatorUtils.GetFadeTo(_animations.Fade,
                    animatedContainer.StartAlpha);

                AddAnimation(Animator.Fade(animatedContainer.CanvasGroup, _animations.Fade, startValue, endValue));
            }
            else
            {
                animatedContainer.ResetAlpha();
            }
#pragma warning restore CS4014

            await WaitEndOfAnimation(_animations.TotalDuration, cancellationToken);

            _onFinishEvent.Invoke();
            onFinishCallback?.Invoke();
        }

        protected override void Reset(AnimationType animationType)
        {
            _animations = new AlphaAnimationsContainer(animationType);

            base.Reset(animationType);
        }
    }
}
