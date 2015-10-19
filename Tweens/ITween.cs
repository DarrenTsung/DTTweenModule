using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
	public interface ITween {
		bool Tick();
		void Start();
	}
	
	public interface ITweenable<T> : ITween where T : struct {
		ITweenable<T> SetEaseType(EaseType easeType);
		ITweenable<T> SetDelay(float delay);
		ITweenable<T> SetDuration(float duration);
	}
}