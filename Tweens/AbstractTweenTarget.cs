using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
	public abstract class AbstractTweenTarget<U, T> : ITweenTarget<T> where T : struct {
		// PRAGMA MARK - Interface
		public abstract void SetValue(T value);
		public abstract T GetValue();
		
    // PRAGMA MARK - Internal
		protected U _target;
	}
}