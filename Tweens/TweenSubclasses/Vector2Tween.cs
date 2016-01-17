using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
	public class Vector2Tween : Tween<Vector2> {
		// PRAGMA MARK - STATIC
		public static Vector2Tween Create() {
			return new Vector2Tween();
		}

		// PRAGMA MARK - Interface
		public Vector2Tween() {
		}

		public Vector2Tween(ITweenTarget<Vector2> target, Vector2 to, float duration) {
			this.Initialize(target, to, duration);
		}

	  // PRAGMA MARK - Internal
		protected override void UpdateValue() {
			Vector2 computedValue = Easers.Ease(this._easeType, this._fromValue, this._toValue, this._elapsedTime, this._duration);
			this._target.SetValue(computedValue);
		}
	}
}
