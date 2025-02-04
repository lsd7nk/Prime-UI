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
                Animator.LoopMove(animatedContainer.RectTransform, _animations.Move, animatedContainer.StartPosition);
            }

            if (_animations.Rotate.IsEnabled)
            {
                Animator.LoopRotate(animatedContainer.RectTransform, _animations.Rotate, animatedContainer.StartRotation);
            }

            if (_animations.Scale.IsEnabled)
            {
                Animator.LoopScale(animatedContainer.RectTransform, _animations.Scale,
                    animatedContainer.StartScale);
            }

            if (_animations.Fade.IsEnabled)
            {
                Animator.LoopFade(animatedContainer.CanvasGroup, _animations.Fade,
                    animatedContainer.StartAlpha);
            }

            onStartCallback?.Invoke();
        }

        public void Reset()
        {
            _animations = new LoopAnimationsContainer();
        }
    }
}