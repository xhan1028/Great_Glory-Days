namespace ScreenEffect
{
  public class EffectOption
  {
    public ScreenEffect effect;

    public float speed;

    public float delay;

    public EffectOption(ScreenEffect effect, float speed = 1f, float delay = 0f)
    {
      this.speed = speed;
      this.delay = delay;
      this.effect = effect;
    }
  }
}