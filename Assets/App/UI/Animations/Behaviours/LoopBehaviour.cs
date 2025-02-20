using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class LoopBehaviour : AnimationBehaviour, IExecutable
    {
        protected override int MaxTweensCount => 8;

        [SerializeField] private LoopAnimationsContainer _animations;

        public LoopBehaviour() : base(AnimationType.Loop)
        {
            Reset();
        }

        public void Execute(Container animatedContainer)
        {
            if (_animations.Move.IsEnabled)
            {
                AddAnimation(Animator.StartLoopMove(animatedContainer.RectTransform, _animations.Move,
                    animatedContainer.StartPosition)
                    .OnComplete(target: this, target => target.LoopMove(animatedContainer)));
            }

            if (_animations.Rotate.IsEnabled)
            {
                AddAnimation(Animator.StartLoopRotate(animatedContainer.RectTransform, _animations.Rotate,
                    animatedContainer.StartRotation)
                    .OnComplete(target: this, target => target.LoopRotate(animatedContainer)));
            }

            if (_animations.Scale.IsEnabled)
            {
                AddAnimation(Animator.StartLoopScale(animatedContainer.RectTransform, _animations.Scale,
                    animatedContainer.StartScale)
                    .OnComplete(target: this, target => target.LoopScale(animatedContainer)));
            }

            if (_animations.Fade.IsEnabled)
            {
                AddAnimation(Animator.StartLoopFade(animatedContainer.CanvasGroup, _animations.Fade,
                    animatedContainer.StartAlpha)
                    .OnComplete(target: this, target => target.LoopFade(animatedContainer)));
            }
        }

        public void StopAnimation()
        {
            StopAnimations();
        }

        private void LoopMove(Container animatedContainer)
        {
            AddAnimation(Animator.LoopMove(animatedContainer.RectTransform, _animations.Move,
                animatedContainer.StartPosition));
        }

        private void LoopRotate(Container animatedContainer)
        {
            AddAnimation(Animator.LoopRotate(animatedContainer.RectTransform, _animations.Rotate,
                    animatedContainer.StartRotation));
        }

        private void LoopScale(Container animatedContainer)
        {
            AddAnimation(Animator.LoopScale(animatedContainer.RectTransform, _animations.Scale,
                    animatedContainer.StartScale));
        }

        private void LoopFade(Container animatedContainer)
        {
            AddAnimation(Animator.LoopFade(animatedContainer.CanvasGroup, _animations.Fade,
                    animatedContainer.StartAlpha));
        }

        private void Reset()
        {
            _animations = new LoopAnimationsContainer();
        }
    }
}