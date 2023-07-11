using System.Collections.Generic;
using Character.Player;
using Cinema;
using ScreenEffect;

namespace Load.Scenes
{
  public class SelectCharacter : SceneStarter
  {
    public CharacterType curSelectedType;

    public override void OnStart()
    {
      PlayBGM("select");
    }

    public void GoToCinema()
    {
      var data = scenes[curSelectedType];
      CinemaManager.Instance.Play(data.cinema, data.scene, true);
    }

    public void GoToMain()
    {
      ChangeScene("Title_Main", ScreenEffects.FadeOut, ScreenEffects.FadeIn);
    }

    public static readonly Dictionary<CharacterType, (string cinema, string scene)> scenes = new()
    {
      { CharacterType.Yisunsin, ("Open_Cinema", "Home") }
    };
  }
}
