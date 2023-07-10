namespace ScreenEffect
{
  public abstract class ScreenEffect
  {
    public bool visible;
    
    public abstract string animationStateName { get; }

    public static implicit operator EffectOption(ScreenEffect effect) => new(effect);
  }
}