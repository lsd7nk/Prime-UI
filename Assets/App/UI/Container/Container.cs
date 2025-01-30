using Prime.UI.Animations;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace Prime.UI
{
    [Serializable]
    public sealed class Container : BaseComponent
    {
        [field: SerializeField] public GraphicRaycaster GraphicRaycaster { get; private set; }
        [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }

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
            if (CanvasGroup == null)
            {
                return;
            }

            CanvasGroup.alpha = StartAlpha;
        }

        public void ResetValues()
        {
            ResetPosition();
            ResetRotation();
            ResetScale();
            ResetAlpha();
        }
    }
}