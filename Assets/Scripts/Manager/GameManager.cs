using Load;
using Load.Scenes;
using ScreenEffect;
using UnityEngine.SceneManagement;

namespace Manager
{
  public class GameManager : SingleTon<GameManager>, IDontDestroy
  {
    public void Die(string retryScene)
    {
      SceneLoader.Instance.Load("Die", null, null, () => FindObjectOfType<Die>().retryScene = retryScene);
    }

    public void Die()
    {
      var sceneName = SceneManager.GetActiveScene().name;
      SceneLoader.Instance.Load("Die", null, null, () => FindObjectOfType<Die>().retryScene = sceneName);
    }
  }
}
