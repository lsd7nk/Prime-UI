using System;

namespace Prime.UI
{
    public interface IBaseAnimatedComponent
    {
        event Action OnShowStartEvent;
        event Action OnShowFinishEvent;

        event Action OnHideStartEvent;
        event Action OnHideFinishEvent;
    }
}