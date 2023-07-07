using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 4;
    private float currentHp;
    private Last_Enemy enemy;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHp = maxHp;
        enemy = GetComponent<Last_Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if ( currentHp <= 0 )
        {
            enemy.OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = Color.white;
    }
}
