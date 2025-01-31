using Cysharp.Threading.Tasks;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class InteractableBehaviour : AnimationBehaviour
    {
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
            switch (_animations.AnimationType)
            {
                case AnimationType.Punch:
                {

                    break;
                }
                case AnimationType.Loop:
                {

                    break;
                }
            }
        }
    }
}
