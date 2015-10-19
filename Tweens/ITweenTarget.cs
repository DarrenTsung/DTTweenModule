using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
	public interface ITweenTarget<T> where T : struct {
		// PRAGMA MARK - Internal
		void SetValue(T value);
		
		T GetValue();
	}
}
