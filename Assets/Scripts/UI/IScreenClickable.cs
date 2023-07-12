using UnityEngine.EventSystems;

namespace UI
{
  public interface IScreenClickable
  {
    public virtual void OnScreenClick(PointerEventData eventData)
    {
    }
  }
}