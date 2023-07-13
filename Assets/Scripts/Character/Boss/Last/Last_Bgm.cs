using UnityEngine;

namespace Character.Boss.Last
{
  public enum BGMType
  {
    Screen = 0, Boss
  }

  public class Last_Bgm : MonoBehaviour
  {
    [SerializeField]
    private AudioClip[] bgmclips;

    private AudioSource audiosource;

    private void Awake()
    {
      audiosource = GetComponent<AudioSource>();
    }

    public void BossBgm(BGMType index)
    {
      audiosource.Stop();

      audiosource.clip = bgmclips[(int) index];
      audiosource.Play();
    }
  }
}
