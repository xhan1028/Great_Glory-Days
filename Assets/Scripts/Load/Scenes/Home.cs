using ScreenEffect;
using UI;
using UnityEngine.EventSystems;

namespace Load.Scenes
{
  public class Home : SceneStarter, IScreenClickable
  {
    public Player_Battles player;

    public void GoToH() => SceneLoader.Instance.Load("Samurai_Battle");

    public void GoToS() => SceneLoader.Instance.Load("Last_Boss2");

    public void GoBattle()
    {
      BattleMode.Arrow.code = "start";
      SceneLoader.Instance.Load
      (
        "ArrowMode",
        new EffectOption(ScreenEffects.FadeOut),
        new EffectOption(ScreenEffects.FadeIn),
        () =>
        {
          var arrowManager = FindObjectOfType<BattleMode.Arrow>();

          BattleMode.Arrow.nextScene = "Chp1";
        },
        () => ChatManager.Instance.Talk("왜놈들이 사방에서 몰려오는군.", "얼른 처치 해야겠군", "W,A,S,D : 회전\nMouse Click : 공격\nE,Q : 스킬 사용")
      );
    }

    public override void OnStart()
    {
      PlayBGM("home");
    }

    public void OnScreenClick(PointerEventData eventData)
    {
      player.Attack();
    }
  }
}
