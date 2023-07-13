using ScreenEffect;

namespace Load.Scenes
{
  public class Chp1 : SceneStarter
  {
    public override void OnStart()
    {
      PlayBGM("chp1");
    }

    public void GoBattle()
      => SceneLoader.Instance.Load
      (
        "Samurai_Battle",
        new EffectOption(ScreenEffects.FadeOut),
        new EffectOption(ScreenEffects.FadeIn)
      );
  }
}