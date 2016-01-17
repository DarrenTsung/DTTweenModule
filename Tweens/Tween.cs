using DT;
using System;
using System.Collections;
using UnityEngine;

// Tons of credit to Prime31 and his github repro ZestKit (https://github.com/prime31/ZestKit)
// Just trying to learn and write the code myself
namespace DT.Tweening {
	public abstract class Tween<T> : ITween, ITweenable<T> where T : struct {
		// PRAGMA MARK - Interface
		public void Initialize(ITweenTarget<T> target, T to, float duration) {
			this.Reset();

			this._target = target;
			this._toValue = to;
			this._duration = duration;
		}

		public void Start() {
			this._fromValue = this._target.GetValue();

			if (this._tweenState == TweenState.COMPLETE) {
				this._tweenState = TweenState.RUNNING;
				Toolbox.GetInstance<TweenManager>().AddTween(this);
			}
		}

		public bool Tick() {
			if (this._tweenState == TweenState.PAUSED) {
				return false;
			}

			if (this._elapsedTime >= this._duration) {
				this._elapsedTime = this._duration;
				this._tweenState = TweenState.COMPLETE;
        if (this._handler != null) {
          this._handler.Invoke();
        }
			}

			if (this._elapsedTime >= 0 && this._elapsedTime <= this._duration) {
				this.UpdateValue();
			}

			this._elapsedTime += Time.deltaTime * this._timeScale;

			if (this._tweenState == TweenState.COMPLETE) {
				return true;
			}

			return false;
		}

		// PRAGMA MARK - Tween Controls
    public ITweenable<T> SetEaseType(EaseType easeType) {
			this._easeType = easeType;
			return this;
		}

		public ITweenable<T> SetDelay(float delay) {
			this._elapsedTime = -delay;
			return this;
		}

		public ITweenable<T> SetDuration(float duration) {
			this._duration = duration;
			return this;
		}

    public ITweenable<T> SetCompletionHandler(Action handler) {
      this._handler = handler;
      return this;
    }

		// PRAGMA MARK - Internal
		protected enum TweenState {
			RUNNING,
			PAUSED,
			COMPLETE
		}

		protected ITweenTarget<T> _target;
		protected T _fromValue;
		protected T _toValue;

		protected EaseType _easeType;

		protected TweenState _tweenState = TweenState.COMPLETE;
    protected Action _handler;
		protected float _duration;
		protected float _elapsedTime;
		protected float _timeScale = 1.0f;

		protected void Reset() {
			this._easeType = EaseType.QuartIn;
			this._tweenState = TweenState.COMPLETE;

			this._duration = 0.0f;
			this._elapsedTime = 0.0f;
			this._timeScale = 1.0f;
      this._handler = null;
		}

		protected abstract void UpdateValue();
	}
}
