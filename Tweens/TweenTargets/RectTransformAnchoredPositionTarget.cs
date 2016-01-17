using DT;
using System.Collections;
using UnityEngine;

namespace DT.Tweening {
  public class RectTransformAnchoredPositionTarget : AbstractTweenTarget<RectTransform,Vector2> {
    // PRAGMA MARK - Public Interface
    public RectTransformAnchoredPositionTarget(RectTransform rectTransform) {
      this._target = rectTransform;
    }

    public override void SetValue(Vector2 value) {
      this._target.anchoredPosition = value;
    }

    public override Vector2 GetValue() {
      return this._target.anchoredPosition;
    }
  }
}