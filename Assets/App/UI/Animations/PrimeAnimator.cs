using UnityEngine;
using PrimeTween;

namespace App.UI.Animations
{
    public static class PrimeAnimator
    {
        public static void Rotate(RectTransform target, RotateAnimation animation,
            Vector3 startValue, Vector3 endValue, bool withoutAnimation = false)
        {
            if (!animation.IsEnabled)
            {
                return;
            }

            if (withoutAnimation)
            {
                target.localRotation = Quaternion.Euler(endValue);

                return;
            }

            GetRotateTween(target, animation, startValue, endValue);
        }

        public static void Scale(RectTransform target, ScaleAnimation animation,
            Vector3 startValue, Vector3 endValue, bool withoutAnimation = false)
        {
            if (!animation.IsEnabled)
            {
                return;
            }

            endValue.z = 1f;

            if (withoutAnimation)
            {
                target.localScale = endValue;

                return;
            }

            startValue.z = 1f;

            GetScaleTween(target, animation, startValue, endValue);
        }

        public static void Move(RectTransform target, MoveAnimation animation,
            Vector3 startValue, Vector3 endValue, bool withoutAnimation = false)
        {
            if (!animation.IsEnabled)
            {
                return;
            }

            if (withoutAnimation)
            {
                target.anchoredPosition3D = endValue;

                return;
            }

            GetMoveTween(target, animation, startValue, endValue);
        }

        public static void Fade(CanvasGroup target, FadeAnimation animation,
            float startValue, float endValue, bool withoutAnimation = false)
        {
            if (!animation.IsEnabled)
            {
                return;
            }

            endValue = Mathf.Clamp01(endValue);

            if (withoutAnimation)
            {
                target.alpha = endValue;

                return;
            }

            startValue = Mathf.Clamp01(startValue);

            GetFadeTween(target, animation, startValue, endValue);
        }

        private static Tween GetRotateTween(RectTransform target, RotateAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return Tween.LocalRotation(target, startValue, endValue, animation.Duration,
                animation.GetEase(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }

        private static Tween GetScaleTween(RectTransform target, ScaleAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return Tween.Scale(target, startValue, endValue, animation.Duration,
                animation.GetEase(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }

        private static Tween GetMoveTween(RectTransform target, MoveAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return Tween.UIAnchoredPosition3D(target, startValue, endValue, animation.Duration,
                animation.GetEase(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }

        private static Tween GetFadeTween(CanvasGroup target, FadeAnimation animation,
            float startValue, float endValue)
        {
            return Tween.Alpha(target, startValue, endValue, animation.Duration,
                animation.GetEase(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }
    }
}