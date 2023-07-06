namespace ScreenEffect
{
  public class None : ScreenEffect
  {
    public override string animationStateName => $"None{(visible ? "0" : "1")}";
  }
}