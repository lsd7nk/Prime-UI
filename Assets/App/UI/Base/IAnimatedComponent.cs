using Cysharp.Threading.Tasks;
using System.Threading;
using System;

namespace Prime.UI
{
    public interface IAnimatedComponent
    {
        public event Action OnShowStartEvent;
        public event Action OnShowFinishEvent;

        public event Action OnHideStartEvent;
        public event Action OnHideFinishEvent;

        public void Show(bool withoutAnimation = false);
        public void Hide(bool withoutAnimation = false);

        public UniTask ShowAsync(CancellationToken cancellationToken = default);
        public UniTask HideAsync(CancellationToken cancellationToken = default);

        public void ShowInstantly();
        public void HideInstantly();
    }
}