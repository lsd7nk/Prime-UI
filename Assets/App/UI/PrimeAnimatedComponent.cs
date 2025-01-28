using Cysharp.Threading.Tasks;
using App.UI.Animations;
using UnityEngine;

namespace App.UI
{
    public abstract class PrimeAnimatedComponent : PrimeComponent
    {
        [field: SerializeField] public PrimeAnimationBehaviour ShowBehaviour { get; private set; }
        [field: SerializeField] public PrimeAnimationBehaviour HideBehaviour { get; private set; }

        public PrimeAnimatedComponent()
        {
            Reset();
        }

        public abstract void Show(bool withoutAnimation = false);
        public abstract void Hide(bool withoutAnimation = false);

        public abstract UniTaskVoid ShowAsync();
        public abstract UniTaskVoid HideAsync();

        protected abstract void ShowInstantly();
        protected abstract void HideInstantly();

        protected override void Reset()
        {
            base.Reset();

            ShowBehaviour = new PrimeAnimationBehaviour(AnimationType.Show);
            HideBehaviour = new PrimeAnimationBehaviour(AnimationType.Hide);
        }
    }
}