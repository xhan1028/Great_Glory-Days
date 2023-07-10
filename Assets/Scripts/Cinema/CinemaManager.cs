using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Load;
using Manager;
using ScreenEffect;
using UnityEngine;
using UnityEngine.Video;
using Utility;

namespace Cinema
{
  public class CinemaManager : SingleTon<CinemaManager>
  {
    public VideoClip[] videoClips;

    private CinemaController controller;

    private string nextScene;

    public Coroutiner<float> playCoroutine;
    
    public bool isPlaying { get; private set; }

    protected override void Awake()
    {
      base.Awake();
      playCoroutine = new(this, PlayRoutine);
    }

    public void Skip()
    {
      playCoroutine.Stop();
      isPlaying = false;
      SceneLoader.Instance.Load(nextScene, new(ScreenEffects.FadeOut, 1.3f, 0.2f), new(ScreenEffects.FadeIn, 0.7f, 1f));
    }

    public void Play(string name, string nextScene, bool isSkipable = true)
      => Play(name, nextScene, new(ScreenEffects.FadeOut), new(ScreenEffects.FadeIn), isSkipable);
    
    public void Play(string name, string nextScene,EffectOption beforeEffect, EffectOption afterEffect, bool isSkipable = true)
    {
      if (isPlaying)
      {
        Debug.LogError("already plaing video clip.");
        return;
      }
      var clip = videoClips.FirstOrDefault(clip => clip.name == name);
      if (clip is null)
        throw new NullReferenceException($"can't find name of clip: {name}");
      isPlaying = true;
      this.nextScene = nextScene;
      
      SceneLoader.Instance.Load("Open_Cinema",beforeEffect, afterEffect, () =>
      {
        controller = FindObjectOfType<CinemaController>();
        controller.player.clip = clip;
        controller.player.Play();
        
        playCoroutine.Start((float)clip.length);
      });
    }

    public IEnumerator PlayRoutine(float second)
    {
      yield return new WaitForSeconds(second);
      Skip();
    }
  }
}
