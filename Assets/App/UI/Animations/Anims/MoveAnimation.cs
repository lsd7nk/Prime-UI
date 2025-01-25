using UnityEngine;
using System;

namespace App.UI.Animations
{
    [Serializable]
    public sealed class MoveAnimation : AbstractAnimation<Vector3>
    {
        [field: SerializeField] public Vector3 CustomPosition { get; private set; }
        [field: SerializeField] public DirectionType Direction { get; private set; }

        public MoveAnimation(AnimationType animationType) : base(animationType)
        {
            CustomPosition = default;
            Direction = PrimeAnimatorConstants.DIRECTION;
        }
    }
}
