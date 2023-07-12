using System;
using ScreenEffect;
using UnityEngine;
using Utility;

namespace Load.Scenes
{
  public class Die : SceneStarter
  {
    public GameObject[] visibleObjs;

    public string retryScene;
    
    public override void OnStart()
    {
      StopBGM();
      
      foreach (var go in visibleObjs)
      {
        go.SetActive(false);
      }
      
      this.NInvoke<Action>(() =>
      {
        foreach (var go in visibleObjs)
        {
          go.SetActive(true);
        }
      }, 5f);
    }
    
    public void GoToMain() =>
      ChangeScene
      (
        "Title_Main", 
        new EffectOption(ScreenEffects.FadeOut, speed: 1.3f), 
        new EffectOption(ScreenEffects.FadeIn, speed: 1.3f, delay: 0.3f)
      );
    
    public void Retry() =>
      ChangeScene
      (
        retryScene, 
        new EffectOption(ScreenEffects.FadeOut, speed: 1.3f), 
        new EffectOption(ScreenEffects.FadeIn, speed: 0.7f, delay: 0.3f)
      );
  }
}