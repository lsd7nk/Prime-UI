using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class InteractableBehaviour : AnimationBehaviour, IExecutable
    {
        [SerializeField] private PunchAnimationsContainer _animations;

        public InteractableBehaviour() : base(AnimationType.Punch) { }

        public void Execute(Container animatedContainer, Action onStartCallback = null)
        {
            ExecuteAsync(animatedContainer, onStartCallback).Forget();
        }

        public async UniTask ExecuteAsync(Container animatedContainer,
            Action onStartCallback = null, Action onFinishCallback = null)
        {
            _onStartEvent.Invoke();
            onStartCallback?.Invoke();

#pragma warning disable CS4014
            if (_animations.Move.IsEnabled)
            {
                animatedContainer.ResetPosition();
                Animator.PunchMove(animatedContainer.RectTransform, _animations.Move);
            }

            if (_animations.Rotate.IsEnabled)
            {
                animatedContainer.ResetRotation();
                Animator.PunchRotate(animatedContainer.RectTransform, _animations.Rotate);
            }

            if (_animations.Scale.IsEnabled)
            {
                animatedContainer.ResetScale();
                Animator.PunchScale(animatedContainer.RectTransform, _animations.Scale);
            }
#pragma warning restore CS4014

            await UniTask.Delay((int)(_animations.TotalDuration * AnimatorConstants.UNI_TASK_DELAY_MULTIPLIER));

            _onFinishEvent.Invoke();
            onFinishCallback?.Invoke();
        }

        protected override void Reset(AnimationType animationType)
        {
            _animations = new PunchAnimationsContainer();

            base.Reset(animationType);
        }
    }
}
