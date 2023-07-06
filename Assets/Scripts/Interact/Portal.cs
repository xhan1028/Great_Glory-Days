using UnityEngine.SceneManagement;

namespace Interact
{
  public class Portal : InteractableObject
  {
    public string toSceneName;
    
    public override void OnInteract()
    {
      SceneManager.LoadScene(toSceneName);
    }
  }
}