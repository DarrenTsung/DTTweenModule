using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
	public class Easers : MonoBehaviour {
		#region mark - Unclamped Lerps
		
		public static float UnclampedLerp(float from, float to, float t) {
			return from + (to - from) * t;
		}
		
		#endregion
		
		
		#region mark - Easers 
		
		public static float Ease(EaseType easeType, float from, float to, float t, float duration) {
			return UnclampedLerp(from, to, EaseHelper.Ease(easeType, t, duration));
		}
		
		#endregion
	}
}