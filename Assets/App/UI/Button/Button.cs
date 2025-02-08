using UnityEngine.EventSystems;
using Prime.UI.Extensions;
using Prime.UI.Animations;
using UnityEngine.UI;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Prime.UI.Button
{
    [RequireComponent(typeof(Container), typeof(GraphicRaycaster))]
    public sealed partial class Button : AnimatedComponent, IButton
    {
        public event Action OnPointerClickEvent;
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;

        [Space(10), Header(PrimeUtils.BUTTON)]
        [SerializeField] private InteractableBehaviour _pointerClickBehaviour;
        [SerializeField] private InteractableBehaviour _pointerDownBehaviour;
        [SerializeField] private InteractableBehaviour _pointerUpBehaviour;

        public void OnPointerClick(PointerEventData eventData)
        {
            _pointerClickBehaviour.Execute(_animatedContainer);
            OnPointerClickEvent?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pointerDownBehaviour.Execute(_animatedContainer);
            OnPointerDownEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pointerUpBehaviour.Execute(_animatedContainer);
            OnPointerUpEvent?.Invoke();
        }

        protected override void Reset()
        {
            base.Reset();

            _pointerClickBehaviour = new InteractableBehaviour();
            _pointerDownBehaviour = new InteractableBehaviour();
            _pointerUpBehaviour = new InteractableBehaviour();
        }
    }


#if UNITY_EDITOR
    public sealed partial class Button : IInitializable
    {
        public void Initialize()
        {
            if (_animatedContainer == null)
            {
                _animatedContainer = GetComponent<Container>();
            }
        }

        private static void CreateImage(GameObject parentObject)
        {
            var imageObject = new GameObject(PrimeUtils.ICON, typeof(RectTransform), typeof(Image));
            var imageRectTransform = imageObject.GetComponent<RectTransform>();

            GameObjectUtility.SetParentAndAlign(imageObject, parentObject);

            imageRectTransform.SetFullScreen(true);
        }

        [MenuItem(PrimeUtils.BUTTON_PATH, false, PrimeUtils.COMPONENT_PRIORITY)]
        private static void CreateComponent(MenuCommand menuCommand)
        {
            var buttonObject = new GameObject(PrimeUtils.BUTTON, typeof(RectTransform), typeof(Button));
            var parentObject = PrimeUtils.GetCanvasAsParent(menuCommand.context as GameObject);

            GameObjectUtility.SetParentAndAlign(buttonObject, parentObject);
            Undo.RegisterCreatedObjectUndo(buttonObject, "Create " + buttonObject.name);

            var buttonRectTransform = buttonObject.GetComponent<RectTransform>();
            var container = buttonObject.GetComponent<Container>();
            var button = buttonObject.GetComponent<Button>();

            buttonRectTransform.SetToCenter(true);

            buttonRectTransform.sizeDelta = new Vector2(320f, 100f);

            CreateImage(buttonObject);

            container.Initialize();
            button.Initialize();
        }
    }
#endif
}