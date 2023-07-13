using System.Collections;
using TMPro;
using UnityEngine;

namespace Character.Boss.Last
{
  public class Last_TMPro : MonoBehaviour
  {
    [SerializeField]
    private float lerpTime = 0.1f;

    private TextMeshProUGUI Boss_Text;

    private void Awake()
    {
      Boss_Text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
      StartCoroutine("ColorLerpLoop");
    }

    private IEnumerator ColorLerpLoop()
    {
      while (true)
      {
        yield return StartCoroutine(ColorLerp(Color.white, Color.red));
        yield return StartCoroutine(ColorLerp(Color.red, Color.white));
      }
    }

    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
      float currentTime = 0.0f;
      float percent = 0.0f;

      while (percent < 1)
      {
        currentTime += Time.deltaTime;
        percent = currentTime / lerpTime;

        Boss_Text.color = Color.Lerp(startColor, endColor, percent);

        yield return null;
      }
    }
  }
}
