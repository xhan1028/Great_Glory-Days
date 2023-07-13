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

          arrowManager.nextScene = "Chp1";
          arrowManager.deadScene = "Home";
        }
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
