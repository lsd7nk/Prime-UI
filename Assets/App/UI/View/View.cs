using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Prime.UI.View
{
    [RequireComponent(typeof(Container))]
    public sealed class View : AnimatedComponent
    {
#if UNITY_EDITOR
        [MenuItem(PrimeUtils.VIEW_PATH, false, PrimeUtils.COMPONENT_PRIORITY)]
        private static void CreateComponent(MenuCommand menuCommand)
        {
            //var gameObject = new GameObject(PrimeUtils.VIEW, typeof(RectTransform), typeof(View));
            //var rootCanvas = gameObject.GetComponent<Canvas>().rootCanvas;

            //if (rootCanvas != null)
            //{
            //    GameObjectUtility.SetParentAndAlign(gameObject, rootCanvas.gameObject);
            //}

            //Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);
        }
#endif
    }
}