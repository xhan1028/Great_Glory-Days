using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace ScreenEffect
{
  public class FadeIn : IScreenEffect
  {
    public float delay { get; set; }
    
    public float speed { get; set; }
    
    public Coroutiner<Image> animation { get; set; }

    public FadeIn(float speed = 1, float delay = 0)
    {
      this.speed = speed;
      this.delay = delay;
      animation = new Coroutiner<Image>(ScreenEffectManager.Instance, AnimationRoutine);
    }

    private IEnumerator AnimationRoutine(Image img)
    {
      var canvasGrp = img.GetComponent<CanvasGroup>();
      canvasGrp.alpha = 1f;
      yield return new WaitForSeconds(delay);
      while (canvasGrp.alpha > 0)
      {
        canvasGrp.alpha -= Time.unscaledDeltaTime / speed;
        yield return new WaitForEndOfFrame();
      }
    }
  }
}