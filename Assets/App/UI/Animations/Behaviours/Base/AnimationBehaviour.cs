using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using System.Threading;
using UnityEngine;
using PrimeTween;
using System;

namespace Prime.UI.Animations
{
    [Serializable]
    public abstract class AnimationBehaviour
    {
        protected abstract int MaxTweensCount { get; }

        [SerializeField] protected UnityEvent _onStartEvent;
        [SerializeField] protected UnityEvent _onFinishEvent;

        protected CancellationTokenSource _cts;

#if UNITY_EDITOR
        [ReadOnly]
#endif
        [SerializeField] private List<Tween> _tweens;

        public AnimationBehaviour(AnimationType animationType)
        {
            Reset(animationType);
        }

        protected async UniTask WaitEndOfAnimation(float duration, CancellationToken cancellationToken = default)
        {
            var token = cancellationToken == default
                ? _cts.Token
                : cancellationToken;

            try
            {
                await UniTask.Delay((int)(duration * AnimatorConstants.UNI_TASK_DELAY_MULTIPLIER),
                    cancellationToken: token);
            }
            catch (OperationCanceledException ex) { }
            finally
            {
                StopAnimations();
            }
        }

        protected void AddAnimation(Tween tween)
        {
            _tweens.Add(tween);
        }

        protected void CancelAnimations()
        {
            _cts.Cancel();
            _cts.Dispose();

            _cts = new CancellationTokenSource();
        }

        protected virtual void Reset(AnimationType animationType)
        {
            _onStartEvent?.RemoveAllListeners();
            _onFinishEvent?.RemoveAllListeners();

            _tweens = new List<Tween>(MaxTweensCount);
            _cts = new CancellationTokenSource();
        }

        private void StopAnimations()
        {
            for (int i = 0; i < _tweens.Count; ++i)
            {
                _tweens[i].Stop();
            }

            _tweens.Clear();
        }
    }
}