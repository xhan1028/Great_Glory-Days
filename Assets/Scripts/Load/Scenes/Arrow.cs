using Character.Player.ArrowBattle;
using UI;
using UnityEngine.EventSystems;

namespace Load.Scenes
{
  public class Arrow : SceneStarter ,IScreenClickable
  {
    public ArrowPlayer player;

    public override void OnStart()
    {
      PlayBGM("arrow");
    }

    public void OnScreenClick(PointerEventData eventData)
    {
      player.Attack();
    }
    
    public override void OnLoadEnd()
    {
      FindObjectOfType<BattleMode.Arrow>().StartPattern(BattleMode.Arrow.code);
    }
  }
}