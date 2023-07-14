using Interact;

namespace ChatingManager
{
  public class Npc : InteractableObject
  {
    public int id;
    public bool isNpc;

    public override void OnInteract()
    {
      ChatManager.Instance.Action(gameObject);
    }
  }
}