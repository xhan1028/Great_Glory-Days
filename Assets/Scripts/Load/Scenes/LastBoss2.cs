using UnityEngine;

namespace Load.Scenes
{
  public enum BGMType
  {
    Screen = 0, Boss
  }

  public class LastBoss2 : SceneStarter
  {
    [SerializeField]
    private string[] bgms;

    public void BossBgm(BGMType index)
    {
      PlayBGM(bgms[(int) index]);
    }

    public override void OnStart()
    {
      BossBgm(BGMType.Screen);
    }
  }
}
