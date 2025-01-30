using Cysharp.Threading.Tasks;
using App.UI.Container;
using UnityEngine;

namespace App.UI.Popup
{
    public sealed class PrimePopup : PrimeAnimatedComponent
    {
        [field: SerializeField] public PrimeContainer Overlay { get; private set; }
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