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
			
			_target = target;
			_toValue = to;
			_duration = duration;
		}
		
		public void Start() {
			_fromValue = _target.GetValue();
			
			if (_tweenState == TweenState.COMPLETE) {
				_tweenState = TweenState.RUNNING;
				TweenManager.Instance.AddTween(this);
			}
		}
		
		public bool Tick() {
			if (_tweenState == TweenState.PAUSED) {
				return false;
			}
			
			if (_elapsedTime >= _duration) {
				_elapsedTime = _duration;
				_tweenState = TweenState.COMPLETE;
			}
			
			if (_elapsedTime >= 0 && _elapsedTime <= _duration) {
				this.UpdateValue();
			}
			
			_elapsedTime += Time.deltaTime * _timeScale;
			
			if (_tweenState == TweenState.COMPLETE) {
				return true;
			}
			
			return false;
		}
		
		// PRAGMA MARK - TWEEN CONTROLS
		public ITweenable<T> SetEaseType(EaseType easeType) {
			_easeType = easeType;
			return this;
		}
		
		public ITweenable<T> SetDelay(float delay) {
			_elapsedTime = -delay;
			return this;
		}
		
		public ITweenable<T> SetDuration(float duration) {
			_duration = duration;
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
		protected float _duration;
		protected float _elapsedTime;
		protected float _timeScale = 1.0f;
		
		protected void Reset() {
			_easeType = EaseType.QuartIn;
			_tweenState = TweenState.COMPLETE;
			
			_duration = 0.0f;
			_elapsedTime = 0.0f;
			_timeScale = 1.0f;
		}
		
		protected abstract void UpdateValue();
	}
}
