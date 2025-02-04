using Cysharp.Threading.Tasks;
using System;

namespace Prime.UI.Animations
{
    public interface IExecutable
    {
        void Execute(Container animatedContainer, Action onStartCallback = null);
    }

    public interface IAsyncExecutable
    {
        UniTask ExecuteAsync(Container animatedContainer,
            Action onStartCallback = null, Action onFinishCallback = null);
    }

    public interface IInstantlyExecutable
    {
        void ExecuteInstantly(Container animatedContainer);
    }
}
