using UnityEngine;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class ScaleAnimation : Animation<Vector3>
    {
        public ScaleAnimation(AnimationType animationType) : base(animationType)
        {

        }
    }
}
