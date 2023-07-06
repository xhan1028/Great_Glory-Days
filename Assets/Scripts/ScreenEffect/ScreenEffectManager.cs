using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenEffect
{
  public class ScreenEffectManager : SingleTon<ScreenEffectManager>
  {
    [SerializeField]
    private Image targetImg;

    public void Play(IScreenEffect screenEffect)
    {
      screenEffect.Play(targetImg);
    }
  }
}