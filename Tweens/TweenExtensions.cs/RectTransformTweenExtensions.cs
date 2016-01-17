using DT;
using System;
using UnityEngine;

namespace DT.Tweening {
  public static class RectTransformTweenExtensions {
    public static ITweenable<Vector2> DTAnchoredPositionTo(this RectTransform transform, Vector2 to, float duration = 0.3f) {
      var tweenTarget = new RectTransformAnchoredPositionTarget(transform);
      var tween = Vector2Tween.Create();
      tween.Initialize(tweenTarget, to, duration);

      return tween;
    }
  }
}