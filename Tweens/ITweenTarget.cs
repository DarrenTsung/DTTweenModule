using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
	public interface ITweenTarget<T> where T : struct {
		// PRAGMA MARK - INTERNAL
		void SetValue(T value);
		
		T GetValue();
	}
}
