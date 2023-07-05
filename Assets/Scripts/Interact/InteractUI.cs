using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interact
{
  public class InteractUI : MonoBehaviour
  {
    [SerializeField]
    private TextMeshProUGUI keyTMP;

    [SerializeField]
    private TextMeshProUGUI textTMP;

    public const char Key = 'F';

    public string text
    {
      get => _text;
      set
      {
        _text = value;
        textTMP.text = _text;
      }
    }

    private string _text;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
      keyTMP.text = Key.ToString();
      canvasGroup = GetComponent<CanvasGroup>();
      Disable();
    }

    public void Enable()
    {
      canvasGroup.alpha = 1f;
    }

    public void Disable()
    {
      canvasGroup.alpha = 0f;
    }
  }
}