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
			float computedValue = (float)Easers.Ease(this._easeType, this._fromValue, this._toValue, this._elapsedTime, this._duration);
			this._target.SetValue(computedValue);
		}
	}
}
