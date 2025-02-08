using UnityEngine.UI;
using UnityEngine;

namespace Prime.UI
{
    public static class PrimeUtils
    {
        public const string CONTAINER_PATH = COMPONENTS_PATH + CONTAINER;
        public const string BUTTON_PATH = COMPONENTS_PATH + BUTTON;
        public const string POPUP_PATH = COMPONENTS_PATH + POPUP;
        public const string VIEW_PATH = COMPONENTS_PATH + VIEW;

        public const string ANIMATED_COMPONENT = "Animated component";
        public const string CONTAINER = "Container";
        public const string BUTTON = "Button";
        public const string POPUP = "Popup";
        public const string VIEW = "View";
        public const string ICON = "Icon";

        public const int COMPONENT_PRIORITY = 0;

        private const string COMPONENTS_PATH = "GameObject/UI/Prime/";

        public static GameObject GetCanvasAsParent(GameObject selectedObject)
        {
            if (selectedObject == null)
            {
                return CreateCanvasAsParent();
            }

            if (selectedObject.TryGetComponent<Canvas>(out _))
            {
                return selectedObject;
            }
            
            return CreateCanvasAsParent(selectedObject);
        }

        private static GameObject CreateCanvasAsParent()
        {
            return CreateCanvasAsParent(new GameObject("MasterCanvas", typeof(RectTransform)));
        }

        private static GameObject CreateCanvasAsParent(GameObject gameObject)
        {
            var canvas = gameObject.AddComponent<Canvas>();

            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 0;

            var canvasScaler = gameObject.AddComponent<CanvasScaler>();

            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
            canvasScaler.referenceResolution = new Vector2(1080, 1920);

            gameObject.AddComponent<GraphicRaycaster>();

            return gameObject;
        }
    }
}