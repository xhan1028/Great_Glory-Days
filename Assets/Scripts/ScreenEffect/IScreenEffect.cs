using UnityEngine.UI;
using Utility;

namespace ScreenEffect
{
  public interface IScreenEffect
  {
    public float delay { get; set; }
    
    public float speed { get; set; }

    public Coroutiner<Image> animation { get; set; }

    public void Play(Image image) => animation.Start(image);
  }
}