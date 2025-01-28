using UnityEngine;
using System;

namespace App.UI.Animations
{
    [Serializable]
    public sealed class ScaleAnimation : AbstractAnimation<Vector3>
    {
        public ScaleAnimation(AnimationType animationType) : base(animationType)
        {

        }
    }
}
