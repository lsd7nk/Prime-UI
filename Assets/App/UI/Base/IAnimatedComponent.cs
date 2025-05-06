using Cysharp.Threading.Tasks;
using System.Threading;

namespace Prime.UI
{
    public interface IAnimatedComponent : IBaseAnimatedComponent
    {
        void Show(bool withoutAnimation = false);
        void Hide(bool withoutAnimation = false);

        UniTask ShowAsync(CancellationToken cancellationToken = default);
        UniTask HideAsync(CancellationToken cancellationToken = default);

        void ShowInstantly();
        void HideInstantly();
    }
}