using System.Collections;
using Manager;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace ScreenEffect
{
  public class ScreenEffectManager : SingleTon<ScreenEffectManager>
  {
    [SerializeField]
    private Image targetImg;

    private Animator targetAnimator;

    private Coroutiner<ScreenEffect, float, float> delayer; 
    
    protected override void Awake()
    {
      base.Awake();
      targetAnimator = targetImg.GetComponent<Animator>();
      delayer = new Coroutiner<ScreenEffect, float, float>(this, Routine);
    }

    private IEnumerator Routine(ScreenEffect effect, float speed, float delay)
    {
      if (effect.visible)
        SetEffect(ScreenEffects.ImmediatelyOut);
      yield return new WaitForSecondsRealtime(delay);
      SetEffect(effect, speed);
      targetImg.raycastTarget = true;
      yield return new WaitForSecondsRealtime(speed);
      targetImg.raycastTarget = false;
    }

    public void Play(ScreenEffect effect, float speed = 1f, float delay = 0f)
    {
      delayer.Start(effect, speed, delay);
    }
    
    public void Play(EffectOption effectOption)
    {
      delayer.Start(effectOption.effect, effectOption.speed, effectOption.delay);
    }

    public void SetEffect(ScreenEffect effect, float speed = 1)
    {
      targetAnimator.SetFloat("speed", 1 / speed);
      targetAnimator.Play(effect.animationStateName);
    }
  }
}