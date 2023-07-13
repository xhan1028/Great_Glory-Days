using Manager;
using UI;
using UnityEngine.EventSystems;

namespace Load.Scenes
{
  public class Dodo_Battle : SceneStarter, IScreenClickable
  {
    public Dodo_Battles Dodo;

    public Timer timer;
    
    public override void OnStart()
    {
      PlayBGM("Em_Middle3");
      timer.StartTimer(60, OnTimerEnd);
    }

    private void OnTimerEnd()
    {
      GameManager.Instance.Die();
    }

    public void OnScreenClick(PointerEventData eventData)
    {
      Dodo.Attack();
    }
    
  }
}