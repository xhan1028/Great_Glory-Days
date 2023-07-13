using System;
using Audio;
using Interact;
using Manager;
using ScreenEffect;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Load.Scenes
{
  public class SceneStarter : MonoBehaviour
  {
    public virtual void OnStart()
    {
    }

    public virtual void OnLoadEnd()
    {
    }

    private void Awake()
    {
      if (FindObjectOfType<GameManager>() is null)
      {
        var manager = Resources.Load<GameObject>("Managers");
        Instantiate(manager).name = "Managers";
      }

      if (this is IScreenClickable screenClickable)
      {
        ScreenClick.Instance.SetActive(true);
        ScreenClick.Instance.onPointClick += screenClickable.OnScreenClick;
      }
      else
        ScreenClick.Instance.SetActive(false);

      SceneLoader.Instance.onSceneChangedAndEndTransition += InstanceOnonSceneChangedAndEndTransition;
    }

    private void InstanceOnonSceneChangedAndEndTransition(string afterchangescene)
    {
      if (afterchangescene == SceneManager.GetActiveScene().name)
        OnLoadEnd();
    }

    private void Start()
    {
      OnStart();
      FindObjectOfType<InteractUI>().GetComponent<CanvasGroup>().alpha = 0;
    }

    protected static void StartScreenEffect(EffectOption effectOption, bool force = false)
    {
      if (force || !SceneLoader.Instance.isLoading)
        ScreenEffectManager.Instance.Play(effectOption);
    }

    protected static void PlayBGM(string bgmName) => AudioManager.Instance.PlayBGM(bgmName);

    protected static void StopBGM() => AudioManager.Instance.StopBGM();

    protected static void ChangeScene(string sceneName) => SceneLoader.Instance.Load(sceneName);

    protected static void ChangeScene(string sceneName, EffectOption beforeEffect, EffectOption afterEffect)
      => SceneLoader.Instance.Load(sceneName, beforeEffect, afterEffect);

    private void OnDestroy()
    {
      if (this is IScreenClickable screenClickable)
        ScreenClick.Instance.onPointClick -= screenClickable.OnScreenClick;
      
      SceneLoader.Instance.onSceneChangedAndEndTransition -= InstanceOnonSceneChangedAndEndTransition;
    }
  }
}
