using UnityEngine;
using UnityEngine.SceneManagement;

namespace Load
{
  public class LoadScene : MonoBehaviour
  {
    public void Load(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
    }
  }
}