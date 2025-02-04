using Cysharp.Threading.Tasks;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Prime.UI.Popup
{
    public sealed class Popup : AnimatedComponent
    {
        [Space(10), Header(PrimeUtils.POPUP)]
        [SerializeField] private Container _overlay;
        [SerializeField] private bool _destroyAfterHide;

        public async override UniTask HideAsync()
        {
            await base.HideAsync();

            if (!_destroyAfterHide)
            {
                return;
            }

            Destroy(gameObject);
        }

        public override void HideInstantly()
        {
            base.HideInstantly();

            if (!_destroyAfterHide)
            {
                return;
            }

            Destroy(gameObject);
        }

#if UNITY_EDITOR
        [MenuItem(PrimeUtils.POPUP_PATH, false, PrimeUtils.COMPONENT_PRIORITY)]
        private static void CreateComponent(MenuCommand menuCommand)
        {
            
        }
#endif
    }
}