using System;

namespace ScreenEffect
{
  public enum Direction
  {
    Left,Right,Up,Down
  }

  public static class DirectionExtensions
  {
    public static char GetChar(this Direction dir) => dir.ToString().ToUpper().ToCharArray()[0];
  }
}