using UnityEngine;
using UnityEngine.Video;

namespace Cinema
{
  public class CinemaController : MonoBehaviour
  {
    public VideoPlayer player;

    public GameObject skipButton;

    public void SkipButton_OnClick()
    {
      CinemaManager.Instance.Skip();
    }
  }
}
