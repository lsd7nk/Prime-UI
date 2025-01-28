using System;

namespace App.UI.Animations
{
    [Serializable]
    public sealed class FadeAnimation : AbstractAnimation<float>
    {
        public FadeAnimation(AnimationType animationType) : base(animationType)
        {

        }
    }
}
