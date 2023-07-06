namespace ScreenEffect
{
  public abstract class ScreenEffect
  {
    public bool visible;
    
    public abstract string animationStateName { get; }
  }
}