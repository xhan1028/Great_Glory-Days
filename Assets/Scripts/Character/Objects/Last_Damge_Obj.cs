using Pool;
using UnityEngine;

namespace Character.Objects
{
  public class Last_Damge_Obj : PoolObject<Last_Damge_Obj>
  {
    [SerializeField]
    private int damage = 10;

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
