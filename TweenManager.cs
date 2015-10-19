using DT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DT.Tweening {
	public class TweenManager : Singleton<TweenManager> {
		protected TweenManager() {}
		
		// PRAGMA MARK - Interface
		public void AddTween(ITween t) {
			_tweens.Add(t);
		}
		
    // PRAGMA MARK - Internal
		protected List<ITween> _tweens;
		
		protected void Awake() {
			_tweens = new List<ITween>();
		}
		
		protected void Update() {
			for (int i = _tweens.Count - 1; i >= 0; i--) {
				ITween t = _tweens[i];
				bool completed = t.Tick();
				
				if (completed) {
					_tweens.RemoveAt(i);
				}
			}
		}
	}
}