using ScreenEffect;

namespace Load.Scenes
{
  public class Chp4 : SceneStarter
  {
    public override void OnStart()
    {
      PlayBGM("Chp4");
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