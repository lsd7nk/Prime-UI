using UnityEngine;
using System;

namespace App.UI.Animations
{
    [Serializable]
    public sealed class RotateAnimation : AbstractAnimation<Vector3>
    {
        public RotateAnimation(AnimationType animationType) : base(animationType)
        {

        }
    }
}
