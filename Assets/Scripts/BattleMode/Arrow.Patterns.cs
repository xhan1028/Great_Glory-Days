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
        new string[]
        {
          "d0.6ds3s L R D U L L R U D L U L  L U L D R",
          "d0.55ds3.5s U R L D L LD L A L L U R D D U U D U D U L L U R D",
          "d0.5ds3.8s U L D L U U D L U L U D  U LD U L ULR D U L R L D U U L   RLUD L L U LR R U D"
        }
      }
    };
  }
}
