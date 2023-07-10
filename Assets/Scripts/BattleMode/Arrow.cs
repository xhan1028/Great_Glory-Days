using UnityEngine;

namespace BattleMode
{
  public class Arrow : MonoBehaviour
  {
    public int maxCount;

    public int curCount;

    public float speed;
    
    [SerializeField]
    private Transform[] spawnLocate;
  }
}
