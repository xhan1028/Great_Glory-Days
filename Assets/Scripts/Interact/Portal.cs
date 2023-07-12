using Load;
using ScreenEffect;
using UnityEngine.SceneManagement;

namespace Interact
{
  public class Portal : InteractableObject
  {
    public string toSceneName;

    public override void OnInteract()
    {
      // SceneManager.LoadScene(toSceneName);
      SceneLoader.Instance.Load
      (
        toSceneName,
        new(ScreenEffects.FadeOut, 0.6f, 0.4f),
        new(ScreenEffects.FadeIn, 0.6f, 1.2f)
      );
    }
  }
}