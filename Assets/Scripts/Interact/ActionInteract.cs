using Load;
using ScreenEffect;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Interact
{
  public class ActionInteract : InteractableObject
  {
    public UnityEvent onInteract;
    
    public override void OnInteract()
    {
      onInteract.Invoke();
    }
  }
}