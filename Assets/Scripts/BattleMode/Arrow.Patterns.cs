using System.Collections.Generic;
using UnityEngine;

namespace BattleMode
{
  public partial class Arrow : MonoBehaviour
  {
    public static readonly Dictionary<string, ArrowPattern> patterns = new()
    {
      {
        "start",
        new []
        {
          "d0.6ds3s L R D U L L R U D L U L  L U L D R",
        }
      },
      {
        "1",
        new []
        {
          "d0.55ds3.5s U R L D L LD L A L L U R D D U U D U D U L L U R D",
          "d0.5ds3.8s U L D L U U D L U L U D  U LD U L ULR D U L R L D U U L   RLUD L L U LR R U D"
        }
      },
      {
        "2",
        new []
        {
          "d0.5ds2.7s  U D U L L  R U D U  LR U D U L L L L U R U D  U R L D U R U L U R  RUL",
          "d0.45ds2.6s L R U  L L L L  R U L R U D L U R D L U D UL D U   U U U D  R U DL U L  U D R L D R L",
          "d0.4ds2.3s L U  D  R U L U D L U R L D U L L R U D  R D U L D U U L U    RLUD D D D D  U L U D R R L U R"
        }
      }
    };

    public static readonly Dictionary<string, (string nextScene, string code)> arrowData = new()
    {
      {"Chp1", ("Chp2","1")},
      {"Chp2", ("Chp3","2")},
    };
    
    public static readonly Dictionary<string, (string nextScene, string code)> cinemaData = new()
    {
      {"Chp3", ("Chp4","Middle3")},
      {"Chp4", ("Last_Boss2", "Load_LastBoss")}
    };
  }
}
