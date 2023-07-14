using Character.Player.Last_Boss;
using ChatingManager;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Load.Scenes
{
  public enum BGMType
  {
    Screen = 0, Boss
  }

  public class LastBoss2 : SceneStarter, IScreenClickable
  {
    public static bool help = false;
    
    [SerializeField]
    private string[] bgms;

    private PlayerWeapon playerWeapon;

    public void BossBgm(BGMType index)
    {
      PlayBGM(bgms[(int) index]);
    }

    public override void OnStart()
    {
      playerWeapon = FindObjectOfType<PlayerWeapon>();
      BossBgm(BGMType.Screen);
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
      playerWeapon.TryAttack();
    }
  }
}
