using UnityEngine;
using PrimeTween;

namespace App.UI.Animations
{
    public static class PrimeAnimator
    {
        #region animations
        public static void RotateInstantly(RectTransform target, Vector3 endValue)
        {
            target.localRotation = Quaternion.Euler(endValue);
        }

        public static Tween Rotate(RectTransform target, RotateAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return GetRotateTween(target, animation, startValue, endValue);
        }

        public static void ScaleInstantly(RectTransform target, Vector3 endValue)
        {
            endValue.z = 1f;
            target.localScale = endValue;
        }

        public static Tween Scale(RectTransform target, ScaleAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            startValue.z = 1f;
            endValue.z = 1f;

            return GetScaleTween(target, animation, startValue, endValue);
        }

        public static void MoveInstantly(RectTransform target, Vector3 endValue)
        {
            target.anchoredPosition3D = endValue;
        }

        public static Tween Move(RectTransform target, MoveAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return GetMoveTween(target, animation, startValue, endValue);
        }

        public static void FadeInstantly(CanvasGroup target, float endValue)
        {
            endValue = Mathf.Clamp01(endValue);
            target.alpha = endValue;
        }

        public static Tween Fade(CanvasGroup target, FadeAnimation animation,
            float startValue, float endValue)
        {
            endValue = Mathf.Clamp01(endValue);
            startValue = Mathf.Clamp01(startValue);

            return GetFadeTween(target, animation, startValue, endValue);
        }
        #endregion

        #region tweens
        private static Tween GetRotateTween(RectTransform target, RotateAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return Tween.LocalRotation(target, startValue, endValue, animation.Duration,
                animation.GetEasing(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }

        private static Tween GetScaleTween(RectTransform target, ScaleAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return Tween.Scale(target, startValue, endValue, animation.Duration,
                animation.GetEasing(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }

        private static Tween GetMoveTween(RectTransform target, MoveAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return Tween.UIAnchoredPosition3D(target, startValue, endValue, animation.Duration,
                animation.GetEasing(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }

        private static Tween GetFadeTween(CanvasGroup target, FadeAnimation animation,
            float startValue, float endValue)
        {
            return Tween.Alpha(target, startValue, endValue, animation.Duration,
                animation.GetEasing(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }
        #endregion
    }
}