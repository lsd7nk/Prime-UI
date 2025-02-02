using Cysharp.Threading.Tasks;

namespace Prime.UI
{
    public interface IAnimatedComponent
    {
        public void Show(bool withoutAnimation = false);
        public void Hide(bool withoutAnimation = false);

        public UniTask ShowAsync();
        public UniTask HideAsync();

        public void ShowInstantly();
        public void HideInstantly();
    }
}