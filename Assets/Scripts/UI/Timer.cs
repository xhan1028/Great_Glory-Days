using System;
using TMPro;
using UnityEngine;

namespace UI
{
  public class Timer : MonoBehaviour
  {
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    private bool isActive;

    public float currentTime;

    private Action callback;

    private float accent;

    public Color accentColor;

    [SerializeField]
    private Color defaultColor;

    public void StartTimer(float second, Action callback, float accentSecond = 10)
    {
      currentTime = second + 4;
      this.callback = callback;
      accent = accentSecond;
      isActive = true;
    }

    private void Update()
    {
      if (!isActive) return;
      if (currentTime <= 0)
      {
        isActive = false;
        callback.Invoke();
        return;
      }
      currentTime -= Time.unscaledDeltaTime;
      var m = Math.DivRem((int)currentTime, 60, out var s);
      textMeshProUGUI.text = $"{m:00}:{s:00}";

      textMeshProUGUI.color = currentTime <= accent ? accentColor : defaultColor;
    }
  }
}