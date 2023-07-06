namespace ScreenEffect
{
  public static class ScreenEffects
  {
    public static readonly None ImmediatelyIn = new() { visible = true };
    
    public static readonly None ImmediatelyOut = new() { visible = false };
    
    public static readonly Fade FadeIn = new() { visible = true };
    
    public static readonly Fade FadeOut = new() { visible = false };

    public static readonly Push PullL2R = new()
    {
      visible = true,
      startDirection = Direction.Left,
      endDirection = Direction.Right
    };

    public static readonly Push PushL2R = new()
    {
      visible = false,
      startDirection = Direction.Left,
      endDirection = Direction.Right
    };
  }
}