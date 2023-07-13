using Pool;
using UnityEngine;

namespace Character.Objects
{
  public class Last_BossObj : PoolObject<Last_BossObj>
  {
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        collision.GetComponent<PlayerHp>().TakeDamage(damage);
        Release();
      }
    }
  }
}
