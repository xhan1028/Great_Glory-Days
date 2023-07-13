using Manager;
using UI;
using UnityEngine.EventSystems;

namespace Load.Scenes
{
  public class SamuraiBattle : SceneStarter, IScreenClickable
  {
    public Player_Battles player;

    public Timer timer;
    
    public override void OnStart()
    {
      PlayBGM("samurai");
      timer.StartTimer(30, OnTimerEnd);
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