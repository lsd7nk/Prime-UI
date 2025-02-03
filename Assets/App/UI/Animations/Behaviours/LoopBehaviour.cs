using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class LoopBehaviour : AnimationBehaviour
    {
        [SerializeField] private LoopAnimationsContainer _loopAnimations;

        public LoopBehaviour() : base(AnimationType.Loop) { }

        public override void Execute(Container animatedContainer,bool withoutAnimation = false,
            Action onStartCallback = null, Action onFinishCallback = null)
        {

        }

        public override async UniTask ExecuteAsync(Container animatedContainer,
            Action onStartCallback = null, Action onFinishCallback = null)
        {

        }

        protected override void Reset(AnimationType animationType)
        {
            _loopAnimations = new LoopAnimationsContainer();

            base.Reset(animationType);
        }
    }
}