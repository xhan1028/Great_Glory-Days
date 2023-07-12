using UI;
using UnityEngine.EventSystems;

namespace Load.Scenes
{
  public class Home : SceneStarter, IScreenClickable
  {
    public Player_Battles player;
    
    public void GoToH() => SceneLoader.Instance.Load("Samurai_Battle");
    
    public void GoToS() => SceneLoader.Instance.Load("Last_Boss2");

    public void OnScreenClick(PointerEventData eventData)
    {
      player.Attack();
    }
  }
}