using Prime.UI.Extensions;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Prime.UI.View
{
    [RequireComponent(typeof(Container))]
    public sealed class View : AnimatedComponent
    {
        public void Initialize()
        {
            if (_animatedContainer == null)
            {
                _animatedContainer = GetComponent<Container>();
            }
        }

#if UNITY_EDITOR
        [MenuItem(PrimeUtils.VIEW_PATH, false, PrimeUtils.COMPONENT_PRIORITY)]
        private static void CreateComponent(MenuCommand menuCommand)
        {
            var viewObject = new GameObject(PrimeUtils.VIEW, typeof(RectTransform), typeof(View));
            var parentObject = PrimeUtils.GetCanvasAsParent(menuCommand.context as GameObject);

            GameObjectUtility.SetParentAndAlign(viewObject, parentObject);
            Undo.RegisterCreatedObjectUndo(viewObject, "Create " + viewObject.name);

            var viewRectTransform = viewObject.GetComponent<RectTransform>();
            var container = viewObject.GetComponent<Container>();
            var view = viewObject.GetComponent<View>();

            viewRectTransform.SetFullScreen(true);

            container.Initialize();
            view.Initialize();
        }
#endif
    }
}