using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Load
{
  public class SceneLoader : SingleTon<SceneLoader>
  {
    public void Load(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
    }
  }
}