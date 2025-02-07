using UnityEngine;

namespace Prime.UI
{
    [RequireComponent(typeof(RectTransform), typeof(CanvasGroup), typeof(Canvas))]
    public abstract class BaseComponent : MonoBehaviour
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public CanvasGroup CanvasGroup { get; private set; }

        public void Initialize()
        {
            if (RectTransform == null)
            {
                RectTransform = GetComponent<RectTransform>();
            }

            if (CanvasGroup == null)
            {
                CanvasGroup = GetComponent<CanvasGroup>();
            }
        }
    }
}