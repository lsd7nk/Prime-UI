using UnityEngine.Events;
using UnityEngine;
using PrimeTween;

namespace App.UI.Animations
{
    public static class PrimeAnimator
    {
        public static void Move(RectTransform target, PrimeAnimation animation, Vector3 startValue, Vector3 endValue, bool withoutAnimation = false, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Move.IsEnabled)
            {
                return;
            }

            if (withoutAnimation)
            {
                target.anchoredPosition3D = endValue;

                onStartCallback?.Invoke();
                onCompleteCallback?.Invoke();

                return;
            }

            // to do: create sequence
        }
    }
}