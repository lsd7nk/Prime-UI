using Cysharp.Threading.Tasks;
using App.UI.Animations;
using App.UI.Container;
using UnityEngine;

namespace App.UI
{
    [DisallowMultipleComponent]
    public abstract class PrimeAnimatedComponent : PrimeComponent
    {
        [field: SerializeField] public PrimeAnimationBehaviour ShowBehaviour { get; private set; }
        [field: SerializeField] public PrimeAnimationBehaviour HideBehaviour { get; private set; }

        [field: SerializeField] public PrimeContainer Container { get; private set; }

        public PrimeAnimatedComponent()
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
            if (ShowBehaviour.Animation.Move.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetMoveFrom(Container.RectTransform,
                    ShowBehaviour.Animation.Move, Container.StartPosition);
                var endValue = PrimeAnimatorUtils.GetMoveTo(Container.RectTransform,
                    ShowBehaviour.Animation.Move, Container.StartPosition);

                PrimeAnimator.Move(Container.RectTransform, ShowBehaviour.Animation.Move, startValue, endValue);
            }
            else
            {
                ResetPosition();
            }

            if (ShowBehaviour.Animation.Rotate.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetRotateFrom(ShowBehaviour.Animation.Rotate,
                    Container.StartRotation);
                var endValue = PrimeAnimatorUtils.GetRotateTo(ShowBehaviour.Animation.Rotate,
                    Container.StartRotation);

                PrimeAnimator.Rotate(Container.RectTransform, ShowBehaviour.Animation.Rotate, startValue, endValue);
            }
            else
            {
                ResetRotation();
            }

            if (ShowBehaviour.Animation.Scale.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetScaleFrom(ShowBehaviour.Animation.Scale,
                    Container.StartScale);
                var endValue = PrimeAnimatorUtils.GetScaleTo(ShowBehaviour.Animation.Scale,
                    Container.StartScale);

                PrimeAnimator.Scale(Container.RectTransform, ShowBehaviour.Animation.Scale, startValue, endValue);
            }
            else
            {
                ResetScale();
            }

            if (ShowBehaviour.Animation.Fade.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetFadeFrom(ShowBehaviour.Animation.Fade,
                    Container.StartAlpha);
                var endValue = PrimeAnimatorUtils.GetFadeTo(ShowBehaviour.Animation.Fade,
                    Container.StartAlpha);

                PrimeAnimator.Fade(Container.CanvasGroup, ShowBehaviour.Animation.Fade, startValue, endValue);
            }
            else
            {
                ResetAlpha();
            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(ShowBehaviour.Animation.TotalDuration * PrimeAnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            ShowBehaviour.OnFinishEvent.Invoke();
        }

        public async virtual UniTask HideAsync()
        {
            HideBehaviour.OnStartEvent.Invoke();

#pragma warning disable CS4014
            if (HideBehaviour.Animation.Move.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetMoveFrom(Container.RectTransform,
                    HideBehaviour.Animation.Move, Container.StartPosition);
                var endValue = PrimeAnimatorUtils.GetMoveTo(Container.RectTransform,
                    HideBehaviour.Animation.Move, Container.StartPosition);

                PrimeAnimator.Move(Container.RectTransform, HideBehaviour.Animation.Move, startValue, endValue);
            }
            else
            {
                ResetPosition();
            }

            if (HideBehaviour.Animation.Rotate.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetRotateFrom(HideBehaviour.Animation.Rotate,
                    Container.StartRotation);
                var endValue = PrimeAnimatorUtils.GetRotateTo(HideBehaviour.Animation.Rotate,
                    Container.StartRotation);

                PrimeAnimator.Rotate(Container.RectTransform, HideBehaviour.Animation.Rotate, startValue, endValue);
            }
            else
            {
                ResetRotation();
            }

            if (HideBehaviour.Animation.Scale.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetScaleFrom(HideBehaviour.Animation.Scale,
                    Container.StartScale);
                var endValue = PrimeAnimatorUtils.GetScaleTo(HideBehaviour.Animation.Scale,
                    Container.StartScale);

                PrimeAnimator.Scale(Container.RectTransform, HideBehaviour.Animation.Scale, startValue, endValue);
            }
            else
            {
                ResetScale();
            }

            if (HideBehaviour.Animation.Fade.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetFadeFrom(HideBehaviour.Animation.Fade,
                    Container.StartAlpha);
                var endValue = PrimeAnimatorUtils.GetFadeTo(HideBehaviour.Animation.Fade,
                    Container.StartAlpha);

                PrimeAnimator.Fade(Container.CanvasGroup, HideBehaviour.Animation.Fade, startValue, endValue);
            }
            else
            {
                ResetAlpha();
            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(HideBehaviour.Animation.TotalDuration * PrimeAnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            HideBehaviour.OnFinishEvent.Invoke();
        }

        protected void ShowInstantly()
        {
            ShowBehaviour.OnStartEvent.Invoke();

            var endMoveValue = PrimeAnimatorUtils.GetMoveTo(Container.RectTransform,
                ShowBehaviour.Animation.Move, Container.StartPosition);

            ResetPosition();
            PrimeAnimator.MoveInstantly(Container.RectTransform, endMoveValue);

            var endRotateValue = PrimeAnimatorUtils.GetRotateTo(ShowBehaviour.Animation.Rotate,
                Container.StartRotation);

            ResetRotation();
            PrimeAnimator.RotateInstantly(Container.RectTransform, endRotateValue);

            var endScaleValue = PrimeAnimatorUtils.GetScaleTo(ShowBehaviour.Animation.Scale,
                Container.StartScale);

            ResetScale();
            PrimeAnimator.ScaleInstantly(Container.RectTransform, endScaleValue);

            var endFadeValue = PrimeAnimatorUtils.GetFadeTo(ShowBehaviour.Animation.Fade,
                Container.StartAlpha);

            ResetAlpha();
            PrimeAnimator.FadeInstantly(Container.CanvasGroup, endFadeValue);

            ShowBehaviour.OnFinishEvent.Invoke();
        }

        protected virtual void HideInstantly()
        {
            HideBehaviour.OnStartEvent.Invoke();

            var endMoveValue = PrimeAnimatorUtils.GetMoveTo(Container.RectTransform,
                HideBehaviour.Animation.Move, Container.StartPosition);

            ResetPosition();
            PrimeAnimator.MoveInstantly(Container.RectTransform, endMoveValue);

            var endRotateValue = PrimeAnimatorUtils.GetRotateTo(HideBehaviour.Animation.Rotate,
                Container.StartRotation);

            ResetRotation();
            PrimeAnimator.RotateInstantly(Container.RectTransform, endRotateValue);

            var endScaleValue = PrimeAnimatorUtils.GetScaleTo(HideBehaviour.Animation.Scale,
                Container.StartScale);

            ResetScale();
            PrimeAnimator.ScaleInstantly(Container.RectTransform, endScaleValue);

            var endFadeValue = PrimeAnimatorUtils.GetFadeTo(HideBehaviour.Animation.Fade,
                Container.StartAlpha);

            ResetAlpha();
            PrimeAnimator.FadeInstantly(Container.CanvasGroup, endFadeValue);

            HideBehaviour.OnFinishEvent.Invoke();
        }

        private void ResetPosition()
        {
            Container.ResetPosition();
        }

        private void ResetRotation()
        {
            Container.ResetRotation();
        }

        private void ResetScale()
        {
            Container.ResetScale();
        }

        private void ResetAlpha()
        {
            Container.ResetAlpha();
        }

        protected override void Reset()
        {
            base.Reset();

            ShowBehaviour = new PrimeAnimationBehaviour(AnimationType.Show);
            HideBehaviour = new PrimeAnimationBehaviour(AnimationType.Hide);
        }
    }
}