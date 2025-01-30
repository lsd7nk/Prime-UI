using App.UI.Animations;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace App.UI.Container
{
    [Serializable]
    public sealed class PrimeContainer : PrimeComponent
    {
        [field: SerializeField] public GraphicRaycaster GraphicRaycaster { get; private set; }
        [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }

        public Vector3 StartPosition { get; private set; } = PrimeAnimatorConstants.START_POSITION;
        public Vector3 StartRotation { get; private set; } = PrimeAnimatorConstants.START_ROTATION;
        public Vector3 StartScale { get; private set; } = PrimeAnimatorConstants.START_SCALE;
        public float StartAlpha { get; private set; } = PrimeAnimatorConstants.START_ALPHA;

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