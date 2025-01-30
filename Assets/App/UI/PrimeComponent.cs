using UnityEngine;

namespace App.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class PrimeComponent : MonoBehaviour
    {
        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                {
                    _rectTransform = GetComponent<RectTransform>();
                }

                return _rectTransform;
            }
        }

        private RectTransform _rectTransform;

        protected virtual void Reset()
        {

        }
    }
}