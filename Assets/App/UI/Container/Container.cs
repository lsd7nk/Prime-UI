using Prime.UI.Animations;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Prime.UI
{
    [Serializable]
    public sealed class Container : BaseComponent
    {
        public Vector3 StartPosition { get; private set; } = AnimatorConstants.START_POSITION;
        public Vector3 StartRotation { get; private set; } = AnimatorConstants.START_ROTATION;
        public Vector3 StartScale { get; private set; } = AnimatorConstants.START_SCALE;
        public float StartAlpha { get; private set; } = AnimatorConstants.START_ALPHA;

        public void ResetPosition()
        {
            RectTransform.anchoredPosition3D = StartPosition;
        }

        public void ResetRotation()
        {
            RectTransform.localEulerAngles = StartRotation;
        }

        public void ResetScale()
        {
            RectTransform.localScale = StartScale;
        }

        public void ResetAlpha()
        {
            CanvasGroup.alpha = StartAlpha;
        }

        public void ResetValues()
        {
            ResetPosition();
            ResetRotation();
            ResetScale();
            ResetAlpha();
        }

#if UNITY_EDITOR
        [MenuItem(PrimeUtils.CONTAINER_PATH, false, PrimeUtils.COMPONENT_PRIORITY)]
        private static void CreateComponent(MenuCommand menuCommand)
        {

        }
#endif
    }
}