using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class RotateAnimation : Animation<Vector3>
    {
        public RotateAnimation(AnimationType animationType) : base(animationType) { }
    }
}
