using Cysharp.Threading.Tasks;
using Prime.UI.Animations;
using UnityEngine;

namespace Prime.UI
{
    [DisallowMultipleComponent]
    public abstract class AnimatedComponent : BaseComponent
    {
        [field: SerializeField] public AnimationBehaviour ShowBehaviour { get; private set; }
        [field: SerializeField] public AnimationBehaviour HideBehaviour { get; private set; }

        [field: SerializeField] public Container AnimatedContainer { get; private set; }

        public AnimatedComponent()
        {
            Reset();
        }

        public void Show(bool withoutAnimation = false)
        {
            if (withoutAnimation)
            {
                ShowInstantly();
            }
            else
            {
                ShowAsync().Forget();
            }
        }

        public void Hide(bool withoutAnimation = false)
        {
            if (withoutAnimation)
            {
                HideInstantly();
            }
            else
            {
                HideAsync().Forget();
            }
        }

        public async UniTask ShowAsync()
        {
            ShowBehaviour.OnStartEvent.Invoke();

#pragma warning disable CS4014
            if (ShowBehaviour.Animations.Move.IsEnabled)
            {
                var startValue = AnimatorUtils.GetMoveFrom(AnimatedContainer.RectTransform,
                    ShowBehaviour.Animations.Move, AnimatedContainer.StartPosition);
                var endValue = AnimatorUtils.GetMoveTo(AnimatedContainer.RectTransform,
                    ShowBehaviour.Animations.Move, AnimatedContainer.StartPosition);

                Animations.Animator.Move(AnimatedContainer.RectTransform, ShowBehaviour.Animations.Move, startValue, endValue);
            }
            else
            {
                ResetPosition();
            }

            if (ShowBehaviour.Animations.Rotate.IsEnabled)
            {
                var startValue = AnimatorUtils.GetRotateFrom(ShowBehaviour.Animations.Rotate,
                    AnimatedContainer.StartRotation);
                var endValue = AnimatorUtils.GetRotateTo(ShowBehaviour.Animations.Rotate,
                    AnimatedContainer.StartRotation);

                Animations.Animator.Rotate(AnimatedContainer.RectTransform, ShowBehaviour.Animations.Rotate, startValue, endValue);
            }
            else
            {
                ResetRotation();
            }

            if (ShowBehaviour.Animations.Scale.IsEnabled)
            {
                var startValue = AnimatorUtils.GetScaleFrom(ShowBehaviour.Animations.Scale,
                    AnimatedContainer.StartScale);
                var endValue = AnimatorUtils.GetScaleTo(ShowBehaviour.Animations.Scale,
                    AnimatedContainer.StartScale);

                Animations.Animator.Scale(AnimatedContainer.RectTransform, ShowBehaviour.Animations.Scale, startValue, endValue);
            }
            else
            {
                ResetScale();
            }

            if (ShowBehaviour.Animations.Fade.IsEnabled)
            {
                var startValue = AnimatorUtils.GetFadeFrom(ShowBehaviour.Animations.Fade,
                    AnimatedContainer.StartAlpha);
                var endValue = AnimatorUtils.GetFadeTo(ShowBehaviour.Animations.Fade,
                    AnimatedContainer.StartAlpha);

                Animations.Animator.Fade(AnimatedContainer.CanvasGroup, ShowBehaviour.Animations.Fade, startValue, endValue);
            }
            else
            {
                ResetAlpha();
            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(ShowBehaviour.Animations.TotalDuration * AnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            ShowBehaviour.OnFinishEvent.Invoke();
        }

        public async virtual UniTask HideAsync()
        {
            HideBehaviour.OnStartEvent.Invoke();

#pragma warning disable CS4014
            if (HideBehaviour.Animations.Move.IsEnabled)
            {
                var startValue = AnimatorUtils.GetMoveFrom(AnimatedContainer.RectTransform,
                    HideBehaviour.Animations.Move, AnimatedContainer.StartPosition);
                var endValue = AnimatorUtils.GetMoveTo(AnimatedContainer.RectTransform,
                    HideBehaviour.Animations.Move, AnimatedContainer.StartPosition);

                Animations.Animator.Move(AnimatedContainer.RectTransform, HideBehaviour.Animations.Move, startValue, endValue);
            }
            else
            {
                ResetPosition();
            }

            if (HideBehaviour.Animations.Rotate.IsEnabled)
            {
                var startValue = AnimatorUtils.GetRotateFrom(HideBehaviour.Animations.Rotate,
                    AnimatedContainer.StartRotation);
                var endValue = AnimatorUtils.GetRotateTo(HideBehaviour.Animations.Rotate,
                    AnimatedContainer.StartRotation);

                Animations.Animator.Rotate(AnimatedContainer.RectTransform, HideBehaviour.Animations.Rotate, startValue, endValue);
            }
            else
            {
                ResetRotation();
            }

            if (HideBehaviour.Animations.Scale.IsEnabled)
            {
                var startValue = AnimatorUtils.GetScaleFrom(HideBehaviour.Animations.Scale,
                    AnimatedContainer.StartScale);
                var endValue = AnimatorUtils.GetScaleTo(HideBehaviour.Animations.Scale,
                    AnimatedContainer.StartScale);

                Animations.Animator.Scale(AnimatedContainer.RectTransform, HideBehaviour.Animations.Scale, startValue, endValue);
            }
            else
            {
                ResetScale();
            }

            if (HideBehaviour.Animations.Fade.IsEnabled)
            {
                var startValue = AnimatorUtils.GetFadeFrom(HideBehaviour.Animations.Fade,
                    AnimatedContainer.StartAlpha);
                var endValue = AnimatorUtils.GetFadeTo(HideBehaviour.Animations.Fade,
                    AnimatedContainer.StartAlpha);

                Animations.Animator.Fade(AnimatedContainer.CanvasGroup, HideBehaviour.Animations.Fade, startValue, endValue);
            }
            else
            {
                ResetAlpha();
            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(HideBehaviour.Animations.TotalDuration * AnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            HideBehaviour.OnFinishEvent.Invoke();
        }

        protected void ShowInstantly()
        {
            ShowBehaviour.OnStartEvent.Invoke();

            var endMoveValue = AnimatorUtils.GetMoveTo(AnimatedContainer.RectTransform,
                ShowBehaviour.Animations.Move, AnimatedContainer.StartPosition);

            ResetPosition();
            Animations.Animator.MoveInstantly(AnimatedContainer.RectTransform, endMoveValue);

            var endRotateValue = AnimatorUtils.GetRotateTo(ShowBehaviour.Animations.Rotate,
                AnimatedContainer.StartRotation);

            ResetRotation();
            Animations.Animator.RotateInstantly(AnimatedContainer.RectTransform, endRotateValue);

            var endScaleValue = AnimatorUtils.GetScaleTo(ShowBehaviour.Animations.Scale,
                AnimatedContainer.StartScale);

            ResetScale();
            Animations.Animator.ScaleInstantly(AnimatedContainer.RectTransform, endScaleValue);

            var endFadeValue = AnimatorUtils.GetFadeTo(ShowBehaviour.Animations.Fade,
                AnimatedContainer.StartAlpha);

            ResetAlpha();
            Animations.Animator.FadeInstantly(AnimatedContainer.CanvasGroup, endFadeValue);

            ShowBehaviour.OnFinishEvent.Invoke();
        }

        protected virtual void HideInstantly()
        {
            HideBehaviour.OnStartEvent.Invoke();

            var endMoveValue = AnimatorUtils.GetMoveTo(AnimatedContainer.RectTransform,
                HideBehaviour.Animations.Move, AnimatedContainer.StartPosition);

            ResetPosition();
            Animations.Animator.MoveInstantly(AnimatedContainer.RectTransform, endMoveValue);

            var endRotateValue = AnimatorUtils.GetRotateTo(HideBehaviour.Animations.Rotate,
                AnimatedContainer.StartRotation);

            ResetRotation();
            Animations.Animator.RotateInstantly(AnimatedContainer.RectTransform, endRotateValue);

            var endScaleValue = AnimatorUtils.GetScaleTo(HideBehaviour.Animations.Scale,
                AnimatedContainer.StartScale);

            ResetScale();
            Animations.Animator.ScaleInstantly(AnimatedContainer.RectTransform, endScaleValue);

            var endFadeValue = AnimatorUtils.GetFadeTo(HideBehaviour.Animations.Fade,
                AnimatedContainer.StartAlpha);

            ResetAlpha();
            Animations.Animator.FadeInstantly(AnimatedContainer.CanvasGroup, endFadeValue);

            HideBehaviour.OnFinishEvent.Invoke();
        }

        private void ResetPosition()
        {
            AnimatedContainer.ResetPosition();
        }

        private void ResetRotation()
        {
            AnimatedContainer.ResetRotation();
        }

        private void ResetScale()
        {
            AnimatedContainer.ResetScale();
        }

        private void ResetAlpha()
        {
            AnimatedContainer.ResetAlpha();
        }

        protected override void Reset()
        {
            base.Reset();

            ShowBehaviour = new AnimationBehaviour(AnimationType.Show);
            HideBehaviour = new AnimationBehaviour(AnimationType.Hide);
        }
    }
}