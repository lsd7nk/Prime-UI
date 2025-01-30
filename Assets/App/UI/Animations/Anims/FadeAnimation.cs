using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public sealed class FadeAnimation : Animation<float>
    {
        public FadeAnimation(AnimationType animationType) : base(animationType) { }
    }
}
