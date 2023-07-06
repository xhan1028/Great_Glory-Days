using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Damge_Obj : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHp>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
