using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Prime.UI.Popup
{
    public sealed class Popup : AnimatedComponent
    {
        [SerializeField] private Container _overlay;
        [SerializeField] private bool _deestroyAfterHide;

        public async override UniTask HideAsync()
        {
            await base.HideAsync();

            if (!_deestroyAfterHide)
            {
                return;
            }

            Destroy(gameObject);
        }

        protected override void HideInstantly()
        {
            base.HideInstantly();

            if (!_deestroyAfterHide)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}