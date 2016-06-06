using DT;
using System;
using System.Collections;
using UnityEngine;

// Taken from here: https://github.com/prime31/ZestKit/blob/master/Assets/ZestKit/Other%20Goodies/SmoothedValues.cs
// Only changing because of naming + style differences
namespace DT.Tweening {
  /// <summary>
  /// SmoothedTarget subclasses were made to address the the propensity to misuse Lerps in Update/FixedUpdate/Coroutines. It is a common
  /// pattern to do things camera follow and other movement via Lerp(from, to, Time.deltaTime * someValue). Lerping like that isnt
  /// really doing much more than jumping towards the to value with an exponential out ease. The target will never reach the to value.
  ///
  /// SmoothedTarget will do the same basic thing with 2 major differences: you can choose the ease type and the target will reach
  /// the to value at duration has passed.
  /// </summary>
  public abstract class SmoothedTarget<T> where T : struct {
    public EaseType easeType = Easers.DefaultEaseType;

    protected float _duration;
    protected float _startTime;

    protected T _fromValue;
    protected T _toValue;
    protected T _currentValue;

    public abstract T Value {
      get; set;
    }

    public SmoothedTarget(T currentValue, float duration = 0.3f) {
      this._duration = duration;
      this._startTime = Time.time;

      this._currentValue = currentValue;
      this._fromValue = currentValue;
      this._toValue = currentValue;
    }

    public void SetToValue(T toValue) {
      if (this._startTime == Time.time) {
        return;
      }

      if (this._toValue.Equals(toValue)) {
        return;
      }

      this._startTime = Time.time;
      this._fromValue = this._currentValue;
      this._toValue = toValue;
    }

    public void ResetFromAndToValues(T fromValue, T toValue) {
      this._startTime = Time.time;
      this._fromValue = fromValue;
      this._toValue = toValue;
    }

    public void Apply(Func<T, T> transformation) {
      this._currentValue = transformation.Invoke(this._currentValue);
      this._fromValue = transformation.Invoke(this._fromValue);
      this._toValue = transformation.Invoke(this._toValue);
    }
  }


  public class SmoothedFloat : SmoothedTarget<float> {
    public SmoothedFloat(float currentValue, float duration = 0.3f) : base(currentValue, duration) {}

    public override float Value {
      get {
        // skip the calculation if we are already at our target
        if (this._currentValue == this._toValue) {
          return this._currentValue;
        }

        // how far along are we?
        var elapsedTime = Mathf.Clamp(Time.time - this._startTime, 0f, this._duration);
        this._currentValue = Easers.Ease(easeType, this._fromValue, this._toValue, elapsedTime, this._duration);

        return this._currentValue;
      }
      set {
        this._currentValue = value;
      }
    }
  }


  public class SmoothedVector2 : SmoothedTarget<Vector2> {
    public SmoothedVector2(Vector2 currentValue, float duration = 0.3f) : base(currentValue, duration) {}

    public override Vector2 Value {
      get {
        // skip the calculation if we are already at our target
        if (this._currentValue == this._toValue) {
          return this._currentValue;
        }

        // how far along are we?
        var elapsedTime = Mathf.Clamp(Time.time - this._startTime, 0f, this._duration);
        this._currentValue = Easers.Ease(easeType, this._fromValue, this._toValue, elapsedTime, this._duration);

        return this._currentValue;
      }
      set {
        this._currentValue = value;
      }
    }
  }


  public class SmoothedVector3 : SmoothedTarget<Vector3> {
    public SmoothedVector3(Vector3 currentValue, float duration = 0.3f) : base(currentValue, duration) {}

    public override Vector3 Value {
      get {
        // skip the calculation if we are already at our target
        if (this._currentValue == this._toValue) {
          return this._currentValue;
        }

        // how far along are we?
        var elapsedTime = Mathf.Clamp(Time.time - this._startTime, 0f, this._duration);
        this._currentValue = Easers.Ease(easeType, this._fromValue, this._toValue, elapsedTime, this._duration);

        return this._currentValue;
      }
      set {
        this._currentValue = value;
      }
    }
  }
}