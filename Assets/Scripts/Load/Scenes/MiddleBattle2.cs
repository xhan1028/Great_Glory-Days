using Manager;
using UI;
using UnityEngine.EventSystems;

namespace Load.Scenes
{
  public class MiddleBattle2 : SceneStarter, IScreenClickable
  {
    public Player_Battles player;

    public Timer timer;
    
    public override void OnStart()
    {
      PlayBGM("Masa");
      timer.StartTimer(40, OnTimerEnd);
    }

    private void OnTimerEnd()
    {
      GameManager.Instance.Die();
    }

    public void OnScreenClick(PointerEventData eventData)
    {
      player.Attack();
    }
    
  }
}