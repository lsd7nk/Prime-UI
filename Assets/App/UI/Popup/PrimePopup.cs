using Cysharp.Threading.Tasks;
using App.UI.Animations;
using App.UI.Container;
using UnityEngine;

namespace App.UI.Popup
{
    public sealed class PrimePopup : PrimeAnimatedComponent
    {
        [field: SerializeField] public PrimeContainer Container { get; private set; }
        [field: SerializeField] public PrimeContainer Overlay { get; private set; }

        [field: SerializeField] public bool DestroyAfterHide { get; private set; }

        private void Awake()
        {
            Show();
        }

        public override void Show(bool withoutAnimation = false)
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

        public override void Hide(bool withoutAnimation = false)
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

        public override async UniTaskVoid ShowAsync()
        {
            ShowBehaviour.OnStartEvent.Invoke();

            if (ShowBehaviour.Animation.Move.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetMoveFrom(Container.RectTransform,
                    ShowBehaviour.Animation.Move, Container.StartPosition);
                var endValue = PrimeAnimatorUtils.GetMoveTo(Container.RectTransform,
                    ShowBehaviour.Animation.Move, Container.StartPosition);

                _ = PrimeAnimator.Move(Container.RectTransform, ShowBehaviour.Animation.Move, startValue, endValue);
            }
            else
            {
                Container.ResetPosition();
            }

            if (ShowBehaviour.Animation.Rotate.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetRotateFrom(ShowBehaviour.Animation.Rotate,
                    Container.StartPosition);
                var endValue = PrimeAnimatorUtils.GetRotateTo(ShowBehaviour.Animation.Rotate,
                    Container.StartPosition);

                _ = PrimeAnimator.Rotate(Container.RectTransform, ShowBehaviour.Animation.Rotate, startValue, endValue);
            }
            else
            {
                Container.ResetRotation();
            }

            if (ShowBehaviour.Animation.Scale.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetScaleFrom(ShowBehaviour.Animation.Scale,
                    Container.StartPosition);
                var endValue = PrimeAnimatorUtils.GetScaleTo(ShowBehaviour.Animation.Scale,
                    Container.StartPosition);

                _ = PrimeAnimator.Scale(Container.RectTransform, ShowBehaviour.Animation.Scale, startValue, endValue);
            }
            else
            {
                Container.ResetScale();
            }

            if (ShowBehaviour.Animation.Fade.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetFadeFrom(ShowBehaviour.Animation.Fade,
                    Container.StartAlpha);
                var endValue = PrimeAnimatorUtils.GetFadeTo(ShowBehaviour.Animation.Fade,
                    Container.StartAlpha);

                _ = PrimeAnimator.Fade(Container.CanvasGroup, ShowBehaviour.Animation.Fade, startValue, endValue);
            }
            else
            {
                Container.ResetAlpha();
            }

            await UniTask.Delay((int)(ShowBehaviour.Animation.TotalDuration * PrimeAnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            ShowBehaviour.OnFinishEvent.Invoke();
        }

        public override async UniTaskVoid HideAsync()
        {
            HideBehaviour.OnStartEvent.Invoke();

            if (HideBehaviour.Animation.Move.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetMoveFrom(Container.RectTransform,
                    HideBehaviour.Animation.Move, Container.StartPosition);
                var endValue = PrimeAnimatorUtils.GetMoveTo(Container.RectTransform,
                    HideBehaviour.Animation.Move, Container.StartPosition);

                _ = PrimeAnimator.Move(Container.RectTransform, HideBehaviour.Animation.Move, startValue, endValue);
            }
            else
            {
                Container.ResetPosition();
            }

            if (HideBehaviour.Animation.Rotate.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetRotateFrom(HideBehaviour.Animation.Rotate,
                    Container.StartPosition);
                var endValue = PrimeAnimatorUtils.GetRotateTo(HideBehaviour.Animation.Rotate,
                    Container.StartPosition);

                _ = PrimeAnimator.Rotate(Container.RectTransform, HideBehaviour.Animation.Rotate, startValue, endValue);
            }
            else
            {
                Container.ResetRotation();
            }

            if (HideBehaviour.Animation.Scale.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetScaleFrom(HideBehaviour.Animation.Scale,
                    Container.StartPosition);
                var endValue = PrimeAnimatorUtils.GetScaleTo(HideBehaviour.Animation.Scale,
                    Container.StartPosition);

                _ = PrimeAnimator.Scale(Container.RectTransform, HideBehaviour.Animation.Scale, startValue, endValue);
            }
            else
            {
                Container.ResetScale();
            }

            if (HideBehaviour.Animation.Fade.IsEnabled)
            {
                var startValue = PrimeAnimatorUtils.GetFadeFrom(HideBehaviour.Animation.Fade,
                    Container.StartAlpha);
                var endValue = PrimeAnimatorUtils.GetFadeTo(HideBehaviour.Animation.Fade,
                    Container.StartAlpha);

                _ = PrimeAnimator.Fade(Container.CanvasGroup, HideBehaviour.Animation.Fade, startValue, endValue);
            }
            else
            {
                Container.ResetAlpha();
            }

            await UniTask.Delay((int)(HideBehaviour.Animation.TotalDuration * PrimeAnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            HideBehaviour.OnFinishEvent.Invoke();
        }

        protected override void ShowInstantly()
        {
            ShowBehaviour.OnStartEvent.Invoke();

            var endMoveValue = PrimeAnimatorUtils.GetMoveTo(Container.RectTransform,
                ShowBehaviour.Animation.Move, Container.StartPosition);

            Container.ResetPosition();
            PrimeAnimator.MoveInstantly(Container.RectTransform, endMoveValue);

            var endRotateValue = PrimeAnimatorUtils.GetRotateTo(ShowBehaviour.Animation.Rotate,
                Container.StartPosition);

            Container.ResetRotation();
            PrimeAnimator.RotateInstantly(Container.RectTransform, endRotateValue);

            var endScaleValue = PrimeAnimatorUtils.GetScaleTo(ShowBehaviour.Animation.Scale,
                Container.StartPosition);

            Container.ResetScale();
            PrimeAnimator.ScaleInstantly(Container.RectTransform, endScaleValue);

            var endFadeValue = PrimeAnimatorUtils.GetFadeTo(ShowBehaviour.Animation.Fade,
                Container.StartAlpha);

            Container.ResetAlpha();
            PrimeAnimator.FadeInstantly(Container.CanvasGroup, endFadeValue);

            ShowBehaviour.OnFinishEvent.Invoke();
        }

        protected override void HideInstantly()
        {
            HideBehaviour.OnStartEvent.Invoke();

            var endMoveValue = PrimeAnimatorUtils.GetMoveTo(Container.RectTransform,
                HideBehaviour.Animation.Move, Container.StartPosition);

            Container.ResetPosition();
            PrimeAnimator.MoveInstantly(Container.RectTransform, endMoveValue);

            var endRotateValue = PrimeAnimatorUtils.GetRotateTo(HideBehaviour.Animation.Rotate,
                Container.StartPosition);

            Container.ResetRotation();
            PrimeAnimator.RotateInstantly(Container.RectTransform, endRotateValue);

            var endScaleValue = PrimeAnimatorUtils.GetScaleTo(HideBehaviour.Animation.Scale,
                Container.StartPosition);

            Container.ResetScale();
            PrimeAnimator.ScaleInstantly(Container.RectTransform, endScaleValue);

            var endFadeValue = PrimeAnimatorUtils.GetFadeTo(HideBehaviour.Animation.Fade,
                Container.StartAlpha);

            Container.ResetAlpha();
            PrimeAnimator.FadeInstantly(Container.CanvasGroup, endFadeValue);

            HideBehaviour.OnFinishEvent.Invoke();

            if (!DestroyAfterHide)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}