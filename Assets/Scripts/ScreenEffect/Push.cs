namespace ScreenEffect
{
  public class Push : ScreenEffect
  {
    public Direction startDirection;

    public Direction endDirection;

    public override string animationStateName =>
      $"{(visible ? "Pull" : "Push")}{startDirection.GetChar()}T{endDirection.GetChar()}";
  }
}