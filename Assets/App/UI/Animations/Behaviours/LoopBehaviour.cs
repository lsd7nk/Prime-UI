using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class LoopBehaviour : IExecutable
    {
        [SerializeField] private LoopAnimationsContainer _animations;

        public LoopBehaviour()
        {
            Reset();
        }

        public void Execute(Container animatedContainer, Action onStartCallback = null)
        {
            if (_animations.Move.IsEnabled)
            {
                Animator.StartLoopMove(animatedContainer.RectTransform, _animations.Move,
                    animatedContainer.StartPosition)
                    .OnComplete(target: this, target => target.LoopMove(animatedContainer));
            }

            if (_animations.Rotate.IsEnabled)
            {
                Animator.StartLoopRotate(animatedContainer.RectTransform, _animations.Rotate,
                    animatedContainer.StartRotation)
                    .OnComplete(target: this, target => target.LoopRotate(animatedContainer));
            }

            if (_animations.Scale.IsEnabled)
            {
                Animator.StartLoopScale(animatedContainer.RectTransform, _animations.Scale,
                    animatedContainer.StartScale)
                    .OnComplete(target: this, target => target.LoopScale(animatedContainer));
            }

            if (_animations.Fade.IsEnabled)
            {
                Animator.StartLoopFade(animatedContainer.CanvasGroup, _animations.Fade,
                    animatedContainer.StartAlpha)
                    .OnComplete(target: this, target => target.LoopFade(animatedContainer));
            }

            onStartCallback?.Invoke();
        }

        private void LoopMove(Container animatedContainer)
        {
            Animator.LoopMove(animatedContainer.RectTransform, _animations.Move,
                animatedContainer.StartPosition);
        }

        private void LoopRotate(Container animatedContainer)
        {
            Animator.LoopRotate(animatedContainer.RectTransform, _animations.Rotate,
                    animatedContainer.StartRotation);
        }

        private void LoopScale(Container animatedContainer)
        {
            Animator.LoopScale(animatedContainer.RectTransform, _animations.Scale,
                    animatedContainer.StartScale);
        }

        private void LoopFade(Container animatedContainer)
        {
            Animator.LoopFade(animatedContainer.CanvasGroup, _animations.Fade,
                    animatedContainer.StartAlpha);
        }

        private void Reset()
        {
            _animations = new LoopAnimationsContainer();
        }
    }
}