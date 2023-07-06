using System;

namespace ScreenEffect
{
  public enum Direction
  {
    Left,Right,Up,Down
  }

  public static class DirectionExts
  {
    public static char GetChar(this Direction dir) => dir switch
    {
      Direction.Left => 'L',
      Direction.Right => 'R',
      Direction.Up => 'U',
      Direction.Down => 'D',
      _ => throw new NotImplementedException()
    };
  }
}