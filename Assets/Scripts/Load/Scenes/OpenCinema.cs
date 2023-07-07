using ScreenEffect;

namespace Load.Scenes
{
  public class OpenCinema : SceneStarter
  {
    public override void OnStart()
    {
      StopBGM();
    }
    
    public void GoToHome() =>
      ChangeScene
      (
        "Home", 
        new EffectOption(ScreenEffects.FadeOut, speed: 2f), 
        new EffectOption(ScreenEffects.FadeIn, speed: 1.7f, delay: 1.2f)
      );
  }
}