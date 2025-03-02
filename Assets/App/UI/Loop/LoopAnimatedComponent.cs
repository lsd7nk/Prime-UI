using Cysharp.Threading.Tasks;
using Prime.UI.Animations;
using Prime.UI.Extensions;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using System;

namespace Prime.UI.Loop
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Container))]
    public sealed partial class LoopAnimatedComponent : MonoBehaviour, IBaseAnimatedComponent
    {
        public event Action OnShowStartEvent;
        public event Action OnShowFinishEvent;

        public event Action OnHideStartEvent;
        public event Action OnHideFinishEvent;

        [SerializeField] private Container _animatedContainer;

        [Space(10), Header(PrimeUtils.LOOP)]
        [SerializeField] private LoopBehaviour _loopBehaviour;

        public LoopAnimatedComponent()
        {
            Reset();
        }

        public void Loop()
        {
            _loopBehaviour.ExecuteAsync(_animatedContainer, default,
                OnShowStartEvent, OnShowFinishEvent).Forget();
        }

        public async UniTask LoopAsync(CancellationToken cancellationToken = default)
        {
            await _loopBehaviour.ExecuteAsync(_animatedContainer, cancellationToken,
                OnShowStartEvent, OnShowFinishEvent);
        }

        private void Reset()
        {
            _loopBehaviour = new LoopBehaviour();
        }
    }


#if UNITY_EDITOR
    public sealed partial class LoopAnimatedComponent : IInitializable
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

        [MenuItem(PrimeUtils.LOOP_PATH, false, PrimeUtils.COMPONENT_PRIORITY)]
        private static void CreateComponent(MenuCommand menuCommand)
        {
            var loopObject = new GameObject(PrimeUtils.LOOP, typeof(RectTransform), typeof(LoopAnimatedComponent));
            var parentObject = PrimeUtils.GetCanvasAsParent(menuCommand.context as GameObject);

            GameObjectUtility.SetParentAndAlign(loopObject, parentObject);
            Undo.RegisterCreatedObjectUndo(loopObject, "Create " + loopObject.name);

            var loopRectTransform = loopObject.GetComponent<RectTransform>();
            var loop = loopObject.GetComponent<LoopAnimatedComponent>();
            var container = loopObject.GetComponent<Container>();

            loopRectTransform.SetToCenter(true);

            loopRectTransform.sizeDelta = new Vector2(600f, 600f);

            CreateImage(loopObject);

            container.Initialize();
            loop.Initialize();
        }
    }
#endif
}