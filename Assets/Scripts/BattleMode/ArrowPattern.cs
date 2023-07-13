using System;

namespace BattleMode
{
  public class ArrowPattern
  {
    public string[] patterns;

    public ArrowPattern(params string[] patterns)
    {
      this.patterns = patterns;
    }

    public static implicit operator ArrowPattern(string[] pattern) => new ArrowPattern(pattern);
    
    public static implicit operator string[](ArrowPattern pattern) => pattern.patterns;
    
  }
}
