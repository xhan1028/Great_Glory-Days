using Character.Boss.Last;
using Pool;
using UnityEngine;

namespace Character.Player.Last_Boss
{
  public class PlayerAttack : PoolObject<PlayerAttack>
  {
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Enemy"))
      {
        collision.GetComponent<Last_EnemyHealth>().TakeDamage(damage);
        Release();
      }
      else if(collision.CompareTag("Boss"))
      {
        collision.GetComponent<Last_Hp>().TakeDamage(damage);
        Release();
      }
    }
  }
}
