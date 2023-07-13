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
          arrowManager.StartPattern(new []
          {
            "d0.6ds3s L R D U L L R U D L U L  L U L D R",
            "d0.55ds3.5s U R L D L LD L A L L U R D D U U D U D U L L U R D",
            "d0.5ds3.8s U L D L U U D L U L U D  U LD U L ULR D U L R L D U U L   RLUD L L U LR R U D"
          });
        }
      );
    }

    public void OnScreenClick(PointerEventData eventData)
    {
      player.Attack();
    }
  }
}
