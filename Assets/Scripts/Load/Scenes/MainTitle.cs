using System;
using Audio;
using ScreenEffect;
using UnityEngine;

namespace Load.Scenes
{
  public class MainTitle : SceneStarter
  {
    public override void OnStart()
    {
      StartScreenEffect(new EffectOption(ScreenEffects.FadeIn, 3f, 1.5f));
      PlayBGM("main");
    }

    public void GoToHelper() =>
      ChangeScene
      (
        "Helper", 
        new EffectOption(ScreenEffects.PushL2R, speed: 1.3f), 
        new EffectOption(ScreenEffects.PullL2R, speed: 1.3f, delay: 0.3f)
      );
    
    public void GoToStart() =>
      ChangeScene
      (
        "Information", 
        new EffectOption(ScreenEffects.PushL2R, speed: 1.3f), 
        new EffectOption(ScreenEffects.FadeIn, speed: 1.3f, delay: 1f)
      );
  }
}