using ChatingManager;
using Manager;
using UI;
using UnityEngine.EventSystems;

namespace Load.Scenes
{
  public class SamuraiBattle : SceneStarter, IScreenClickable
  {
    public static bool help;
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

    public override void OnLoadEnd()
    {
      if (!help)
      {
        help = true;
        ChatManager.Instance.Talk("A,D : 이동\nSpace : 점프\nMouse Click : 공격");
      }
    }

    public void OnScreenClick(PointerEventData eventData)
    {
      player.Attack();
    }
  }
}