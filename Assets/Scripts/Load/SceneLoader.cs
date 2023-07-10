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
    public delegate void SceneEventListener(string afterChangeScene);

    public event SceneEventListener onSceneChanged;

    public bool isLoading { get; private set; }

    private void Start()
    {
      onSceneChanged?.Invoke(SceneManager.GetActiveScene().name);
    }

    public void Load(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
      onSceneChanged?.Invoke(sceneName);
    }

    public void Load
    (
      string sceneName,
      EffectOption beforeEffect,
      EffectOption afterEffect,
      Action beforeEffectAfterAction = null,
      Action afterEffectAfterAction = null
    )
    {
      if (isLoading)
      {
        Debug.LogError("already loading scene");
        return;
      }

      StartCoroutine(
        AsyncLoadScene
        (
          sceneName,
          beforeEffect,
          afterEffect,
          beforeEffectAfterAction,
          afterEffectAfterAction
        ));
    }

    public IEnumerator AsyncLoadScene
    (
      string sceneName,
      EffectOption beforeEffect,
      EffectOption afterEffect,
      Action beforeEffectAfterAction = null,
      Action afterEffectAfterAction = null
    )
    {
      isLoading = true;
      if (beforeEffect is not null)
      {
        ScreenEffectManager.Instance.Play(beforeEffect);
        yield return new WaitForSecondsRealtime(beforeEffect.speed + beforeEffect.delay);
      }

      var async = SceneManager.LoadSceneAsync(sceneName);
      yield return async;
      onSceneChanged?.Invoke(sceneName);
      
      beforeEffectAfterAction?.Invoke();

      if (afterEffect is not null)
      {
        ScreenEffectManager.Instance.Play(afterEffect);
        yield return new WaitForSecondsRealtime(afterEffect.speed + afterEffect.delay);
      }

      afterEffectAfterAction?.Invoke();

      isLoading = false;
    }
  }
}
