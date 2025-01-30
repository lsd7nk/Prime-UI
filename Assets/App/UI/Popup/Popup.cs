using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Prime.UI.Popup
{
    public sealed class Popup : AnimatedComponent
    {
        [field: SerializeField] public Container Overlay { get; private set; }
        [field: SerializeField] public bool DestroyAfterHide { get; private set; }

        public async override UniTask HideAsync()
        {
            await base.HideAsync();

            if (!DestroyAfterHide)
            {
                return;
            }

            Destroy(gameObject);
        }

        protected override void HideInstantly()
        {
            base.HideInstantly();

            if (!DestroyAfterHide)
            {
                return;
            }

            Destroy(gameObject);
        }
    }
}