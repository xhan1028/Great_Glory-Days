using System;
using System.Collections;
using Manager;
using ScreenEffect;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Load
{
  public class SceneLoader : SingleTon<SceneLoader>
  {
    public bool isLoading { get; private set; }

    public void Load(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
    }

    public void Load(string sceneName, EffectOption beforeEffect, EffectOption afterEffect)
    {
      if (isLoading)
      {
        Debug.LogError("already loading scene");
        return;
      }

      StartCoroutine(AsyncLoadScene(sceneName, beforeEffect, afterEffect));
    }

    public IEnumerator AsyncLoadScene(string sceneName, EffectOption beforeEffect, EffectOption afterEffect)
    {
      isLoading = true;
      if (beforeEffect is not null)
      {
        ScreenEffectManager.Instance.Play(beforeEffect);
        yield return new WaitForSecondsRealtime(beforeEffect.speed + beforeEffect.delay);
      }

      var async = SceneManager.LoadSceneAsync(sceneName);
      yield return async;
      if (afterEffect is not null)
      {
        ScreenEffectManager.Instance.Play(afterEffect);
        yield return new WaitForSecondsRealtime(afterEffect.speed + afterEffect.delay);
      }

      isLoading = false;
    }
  }
}