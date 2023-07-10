using System;
using Audio;
using ScreenEffect;
using UnityEngine;

namespace Load.Scenes
{
  public class Helper : SceneStarter
  {
    public override void OnStart()
    {
      PlayBGM("helper");
    }
    
    public void GoToMain() =>
      ChangeScene
      (
        "Title_Main", 
        new EffectOption(ScreenEffects.PushL2R, speed: 1.3f), 
        new EffectOption(ScreenEffects.PullL2R, speed: 1.3f, delay: 0.3f)
      );
  }
}