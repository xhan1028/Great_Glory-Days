namespace ScreenEffect
{
  public class Fade : ScreenEffect
  {
    public override string animationStateName => $"Fade{(visible ? "In" : "Out")}";
  }
}