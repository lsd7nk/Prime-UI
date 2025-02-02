using System;

namespace Prime.UI.Animations
{
    public static class AnimationsUtils
    {
        public static NotInteractableAnimationType GetNotInteractableAnimationType(AnimationType animationType)
        {
            return animationType switch
            {
                AnimationType.Show => NotInteractableAnimationType.Show,
                AnimationType.Hide => NotInteractableAnimationType.Hide,
                _ => throw new NotImplementedException("Not supported animation type for NotInteractableBehaviour")
            };
        }

        public static InteractableAnimationType GetInteractableAnimationType(AnimationType animationType)
        {
            return animationType switch
            {
                AnimationType.Punch => InteractableAnimationType.Punch,
                AnimationType.State => InteractableAnimationType.State,
                _ => throw new NotImplementedException("Not supported animation type for InteractableBehaviour")
            };
        }

        public static AnimationType GetAnimationType(NotInteractableAnimationType animationType)
        {
            return animationType switch
            {
                NotInteractableAnimationType.Show => AnimationType.Show,
                NotInteractableAnimationType.Hide => AnimationType.Hide,
                _ => throw new NotImplementedException("Not supported animation type for AnimatedBehaviour")
            };
        }

        public static AnimationType GetAnimationType(InteractableAnimationType animationType)
        {
            return animationType switch
            {
                InteractableAnimationType.Punch => AnimationType.Punch,
                InteractableAnimationType.State => AnimationType.State,
                _ => throw new NotImplementedException("Not supported animation type for AnimatedBehaviour")
            };
        }
    }
}
