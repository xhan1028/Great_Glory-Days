using ScreenEffect;

namespace Load.Scenes
{
  public class Chp : SceneStarter
  {
    public string bgm;

    public string nextScene;
    
    public override void OnStart()
    {
      PlayBGM(bgm);
    }

    public void GoBattle()
      => SceneLoader.Instance.Load
      (
        nextScene,
        new EffectOption(ScreenEffects.FadeOut),
        new EffectOption(ScreenEffects.FadeIn)
      );
  }
}
