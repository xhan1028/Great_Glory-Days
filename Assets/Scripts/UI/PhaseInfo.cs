using System;
using BattleMode;
using TMPro;
using UnityEngine;

namespace UI
{
  public class PhaseInfo : MonoBehaviour
  {
    private Arrow manager;
    
    private TextMeshProUGUI text;
    
    private Animator animator;

    private void Awake()
    {
      text = GetComponent<TextMeshProUGUI>();
      animator = GetComponent<Animator>();
      manager = FindObjectOfType<Arrow>();
    }

    private void SetTextToIndex()
    {
      text.text = $"Phase {manager.phase + 1}";
    }

    private void SetTextToStart()
    {
      text.text = "Start";
    }

    private void StartNextPattern()
    {
      manager.Play2();
    }

    public void StartAnim()
    {
      animator.Play("Enable");
    }
  }
}
