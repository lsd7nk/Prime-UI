using Cysharp.Threading.Tasks;
using Prime.UI.Animations;
using UnityEngine;

namespace Prime.UI
{
    [DisallowMultipleComponent]
    public abstract class AnimatedComponent : BaseComponent
    {
        [SerializeField] private AnimationBehaviour _showBehaviour;
        [SerializeField] private AnimationBehaviour _hideBehaviour;

        [SerializeField] private Container _animatedContainer;

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
            _showBehaviour.OnStartEvent.Invoke();

#pragma warning disable CS4014
            if (_showBehaviour.Animations.Move.IsEnabled)
            {
                var startValue = AnimatorUtils.GetMoveFrom(_animatedContainer.RectTransform,
                    _showBehaviour.Animations.Move, _animatedContainer.StartPosition);
                var endValue = AnimatorUtils.GetMoveTo(_animatedContainer.RectTransform,
                    _showBehaviour.Animations.Move, _animatedContainer.StartPosition);

                Animations.Animator.Move(_animatedContainer.RectTransform, _showBehaviour.Animations.Move, startValue, endValue);
            }
            else
            {
                ResetPosition();
            }

            if (_showBehaviour.Animations.Rotate.IsEnabled)
            {
                var startValue = AnimatorUtils.GetRotateFrom(_showBehaviour.Animations.Rotate,
                    _animatedContainer.StartRotation);
                var endValue = AnimatorUtils.GetRotateTo(_showBehaviour.Animations.Rotate,
                    _animatedContainer.StartRotation);

                Animations.Animator.Rotate(_animatedContainer.RectTransform, _showBehaviour.Animations.Rotate, startValue, endValue);
            }
            else
            {
                ResetRotation();
            }

            if (_showBehaviour.Animations.Scale.IsEnabled)
            {
                var startValue = AnimatorUtils.GetScaleFrom(_showBehaviour.Animations.Scale,
                    _animatedContainer.StartScale);
                var endValue = AnimatorUtils.GetScaleTo(_showBehaviour.Animations.Scale,
                    _animatedContainer.StartScale);

                Animations.Animator.Scale(_animatedContainer.RectTransform, _showBehaviour.Animations.Scale, startValue, endValue);
            }
            else
            {
                ResetScale();
            }

            if (_showBehaviour.Animations.Fade.IsEnabled)
            {
                var startValue = AnimatorUtils.GetFadeFrom(_showBehaviour.Animations.Fade,
                    _animatedContainer.StartAlpha);
                var endValue = AnimatorUtils.GetFadeTo(_showBehaviour.Animations.Fade,
                    _animatedContainer.StartAlpha);

                Animations.Animator.Fade(_animatedContainer.CanvasGroup, _showBehaviour.Animations.Fade, startValue, endValue);
            }
            else
            {
                ResetAlpha();
            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(_showBehaviour.Animations.TotalDuration * AnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            _showBehaviour.OnFinishEvent.Invoke();
        }

        public async virtual UniTask HideAsync()
        {
            _hideBehaviour.OnStartEvent.Invoke();

#pragma warning disable CS4014
            if (_hideBehaviour.Animations.Move.IsEnabled)
            {
                var startValue = AnimatorUtils.GetMoveFrom(_animatedContainer.RectTransform,
                    _hideBehaviour.Animations.Move, _animatedContainer.StartPosition);
                var endValue = AnimatorUtils.GetMoveTo(_animatedContainer.RectTransform,
                    _hideBehaviour.Animations.Move, _animatedContainer.StartPosition);

                Animations.Animator.Move(_animatedContainer.RectTransform, _hideBehaviour.Animations.Move, startValue, endValue);
            }
            else
            {
                ResetPosition();
            }

            if (_hideBehaviour.Animations.Rotate.IsEnabled)
            {
                var startValue = AnimatorUtils.GetRotateFrom(_hideBehaviour.Animations.Rotate,
                    _animatedContainer.StartRotation);
                var endValue = AnimatorUtils.GetRotateTo(_hideBehaviour.Animations.Rotate,
                    _animatedContainer.StartRotation);

                Animations.Animator.Rotate(_animatedContainer.RectTransform, _hideBehaviour.Animations.Rotate, startValue, endValue);
            }
            else
            {
                ResetRotation();
            }

            if (_hideBehaviour.Animations.Scale.IsEnabled)
            {
                var startValue = AnimatorUtils.GetScaleFrom(_hideBehaviour.Animations.Scale,
                    _animatedContainer.StartScale);
                var endValue = AnimatorUtils.GetScaleTo(_hideBehaviour.Animations.Scale,
                    _animatedContainer.StartScale);

                Animations.Animator.Scale(_animatedContainer.RectTransform, _hideBehaviour.Animations.Scale, startValue, endValue);
            }
            else
            {
                ResetScale();
            }

            if (_hideBehaviour.Animations.Fade.IsEnabled)
            {
                var startValue = AnimatorUtils.GetFadeFrom(_hideBehaviour.Animations.Fade,
                    _animatedContainer.StartAlpha);
                var endValue = AnimatorUtils.GetFadeTo(_hideBehaviour.Animations.Fade,
                    _animatedContainer.StartAlpha);

                Animations.Animator.Fade(_animatedContainer.CanvasGroup, _hideBehaviour.Animations.Fade, startValue, endValue);
            }
            else
            {
                ResetAlpha();
            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(_hideBehaviour.Animations.TotalDuration * AnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            _hideBehaviour.OnFinishEvent.Invoke();
        }

        protected void ShowInstantly()
        {
            _showBehaviour.OnStartEvent.Invoke();

            var endMoveValue = AnimatorUtils.GetMoveTo(_animatedContainer.RectTransform,
                _showBehaviour.Animations.Move, _animatedContainer.StartPosition);

            ResetPosition();
            Animations.Animator.MoveInstantly(_animatedContainer.RectTransform, endMoveValue);

            var endRotateValue = AnimatorUtils.GetRotateTo(_showBehaviour.Animations.Rotate,
                _animatedContainer.StartRotation);

            ResetRotation();
            Animations.Animator.RotateInstantly(_animatedContainer.RectTransform, endRotateValue);

            var endScaleValue = AnimatorUtils.GetScaleTo(_showBehaviour.Animations.Scale,
                _animatedContainer.StartScale);

            ResetScale();
            Animations.Animator.ScaleInstantly(_animatedContainer.RectTransform, endScaleValue);

            var endFadeValue = AnimatorUtils.GetFadeTo(_showBehaviour.Animations.Fade,
                _animatedContainer.StartAlpha);

            ResetAlpha();
            Animations.Animator.FadeInstantly(_animatedContainer.CanvasGroup, endFadeValue);

            _showBehaviour.OnFinishEvent.Invoke();
        }

        protected virtual void HideInstantly()
        {
            _hideBehaviour.OnStartEvent.Invoke();

            var endMoveValue = AnimatorUtils.GetMoveTo(_animatedContainer.RectTransform,
                _hideBehaviour.Animations.Move, _animatedContainer.StartPosition);

            ResetPosition();
            Animations.Animator.MoveInstantly(_animatedContainer.RectTransform, endMoveValue);

            var endRotateValue = AnimatorUtils.GetRotateTo(_hideBehaviour.Animations.Rotate,
                _animatedContainer.StartRotation);

            ResetRotation();
            Animations.Animator.RotateInstantly(_animatedContainer.RectTransform, endRotateValue);

            var endScaleValue = AnimatorUtils.GetScaleTo(_hideBehaviour.Animations.Scale,
                _animatedContainer.StartScale);

            ResetScale();
            Animations.Animator.ScaleInstantly(_animatedContainer.RectTransform, endScaleValue);

            var endFadeValue = AnimatorUtils.GetFadeTo(_hideBehaviour.Animations.Fade,
                _animatedContainer.StartAlpha);

            ResetAlpha();
            Animations.Animator.FadeInstantly(_animatedContainer.CanvasGroup, endFadeValue);

            _hideBehaviour.OnFinishEvent.Invoke();
        }

        private void ResetPosition()
        {
            _animatedContainer.ResetPosition();
        }

        private void ResetRotation()
        {
            _animatedContainer.ResetRotation();
        }

        private void ResetScale()
        {
            _animatedContainer.ResetScale();
        }

        private void ResetAlpha()
        {
            _animatedContainer.ResetAlpha();
        }

        protected override void Reset()
        {
            base.Reset();

            _showBehaviour = new AnimationBehaviour(AnimationType.Show);
            _hideBehaviour = new AnimationBehaviour(AnimationType.Hide);
        }
    }
}