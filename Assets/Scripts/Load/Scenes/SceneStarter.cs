using System;
using Audio;
using Manager;
using ScreenEffect;
using UnityEngine;

namespace Load.Scenes
{
  public abstract class SceneStarter : MonoBehaviour
  {
    public virtual void OnStart()
    {
      if (FindObjectOfType<GameManager>() is null)
      {
        var manager = Resources.Load<GameObject>("Managers");
        Instantiate(manager).name = "Managers";
      }
    }

    private void Start()
    {
      OnStart();
    }

    protected static void StartScreenEffect(EffectOption effectOption)
    {
      if (!SceneLoader.Instance.isLoading)
        ScreenEffectManager.Instance.Play(effectOption);
    }

    protected static void PlayBGM(string bgmName) => AudioManager.Instance.PlayBGM(bgmName);

    protected static void StopBGM() => AudioManager.Instance.StopBGM();

    protected static void ChangeScene(string sceneName) => SceneLoader.Instance.Load(sceneName);

    protected static void ChangeScene(string sceneName, EffectOption beforeEffect, EffectOption afterEffect)
      => SceneLoader.Instance.Load(sceneName, beforeEffect, afterEffect);
  }
}