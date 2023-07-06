using System;
using Audio;
using ScreenEffect;
using UnityEngine;

namespace Load.Scenes
{
  public class MainTitle : MonoBehaviour
  {
    private void Start()
    {
      ScreenEffectManager.Instance.Play(new FadeIn(3));
      AudioManager.Instance.PlayBGM("main");
    }
  }
}