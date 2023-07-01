using Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
  public class ScreenClick : SingleTon<ScreenClick>, IPointerClickHandler
  {
    public delegate void PointerEventListener(PointerEventData eventData);

    public event PointerEventListener onPointClick;
    
    public void OnPointerClick(PointerEventData eventData) => onPointClick?.Invoke(eventData);
  }
}
