using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
	public interface ITween {
		bool Tick();
		void Start();
	}
}