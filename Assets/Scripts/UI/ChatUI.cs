using System;
using Load;
using UnityEngine;

namespace UI
{
  public class ChatUI : MonoBehaviour
  {
    private void Awake()
    {
      gameObject.SetActive(false);
      SceneLoader.Instance.onSceneChanged += SceneLoader_OnSceneChanged;
    }

    private void SceneLoader_OnSceneChanged(string changedScene)
    {
      var m = FindObjectOfType<Player_Movement>();
      if(m is not null) m.chatUI = gameObject;
    }
  }
}