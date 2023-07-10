using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackPoint : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Last_EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Boss"))
        {
            collision.GetComponent<Last_Hp>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
