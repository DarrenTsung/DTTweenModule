using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
	public class FloatTween : Tween<float> {
		// PRAGMA MARK - STATIC 
		public static FloatTween Create() {
			return new FloatTween();
		}
		
		// PRAGMA MARK - Interface
		public FloatTween() {
		}
		
		public FloatTween(ITweenTarget<float> target, float to, float duration) {
			this.Initialize(target, to, duration);
		}
		
	  // PRAGMA MARK - Internal
		protected override void UpdateValue() {
			float computedValue = (float)Easers.Ease(_easeType, _fromValue, _toValue, _elapsedTime, _duration);
			_target.SetValue(computedValue);
		}
	}
}
