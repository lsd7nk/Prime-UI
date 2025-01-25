using PrimeTween;
using System;

namespace App.UI.Animations
{
    public static class PrimeAnimatorExtensions
    {
        public static Easing GetEase(this AbstractAnimation animation)
        {
            return animation.EaseType switch
            {
                EaseType.Ease => animation.Ease,
                EaseType.AnimationCurve => animation.AnimationCurve,
                _ => throw new NotImplementedException()
            };
        }
    }
}
