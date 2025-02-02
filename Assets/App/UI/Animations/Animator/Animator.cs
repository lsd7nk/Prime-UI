using UnityEngine;
using PrimeTween;

namespace Prime.UI.Animations
{
    public static class Animator
    {
        #region animations (punch & loop)
        public static Tween MovePunch(RectTransform target, MoveAnimation animation)
        {
            return Tween.PunchLocalPosition(target, animation.By, animation.Duration, animation.Frequency, asymmetryFactor: animation.AsymmetryFactor, startDelay: animation.StartDelay);
        }

        public static Tween RotatePunch(RectTransform target, RotateAnimation animation)
        {
            return Tween.PunchLocalRotation(target, animation.By, animation.Duration, animation.Frequency, asymmetryFactor: animation.AsymmetryFactor, startDelay: animation.StartDelay);
        }

        public static Tween ScalePunch(RectTransform target, ScaleAnimation animation)
        {
            return Tween.PunchScale(target, animation.By, animation.Duration, animation.Frequency, asymmetryFactor: animation.AsymmetryFactor, startDelay: animation.StartDelay);
        }
        #endregion

        #region animations (show & hide)
        public static void MoveInstantly(RectTransform target, Vector3 endValue)
        {
            target.anchoredPosition3D = endValue;
        }

        public static Tween Move(RectTransform target, MoveAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return Tween.UIAnchoredPosition3D(target, startValue, endValue, animation.Duration,
                animation.GetEasing(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }

        public static void RotateInstantly(RectTransform target, Vector3 endValue)
        {
            target.localRotation = Quaternion.Euler(endValue);
        }

        public static Tween Rotate(RectTransform target, RotateAnimation animation,
            Vector3 startValue, Vector3 endValue)
        {
            return Tween.LocalRotation(target, startValue, endValue, animation.Duration,
                animation.GetEasing(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
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

            return Tween.Scale(target, startValue, endValue, animation.Duration,
                animation.GetEasing(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
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

            return Tween.Alpha(target, startValue, endValue, animation.Duration,
                animation.GetEasing(), animation.NumberOfCycles, animation.CycleMode, animation.StartDelay);
        }
        #endregion
    }
}