using Load;
using Load.Scenes;
using ScreenEffect;

namespace Manager
{
  public class GameManager : SingleTon<GameManager>, IDontDestroy
  {
    public void Die(string retryScene)
    {
      SceneLoader.Instance.Load("Die", ScreenEffects.ImmediatelyOut, ScreenEffects.ImmediatelyIn,
        () => FindObjectOfType<Die>().retryScene = retryScene);
    }
  }
}