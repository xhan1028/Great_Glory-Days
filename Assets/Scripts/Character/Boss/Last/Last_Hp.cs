using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Last_Hp : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 500;
    private float currentHP;
    private SpriteRenderer spriterenderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if ( currentHP <= 0 )
        {
            SceneManager.LoadScene("lastbossdie");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        spriterenderer.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        spriterenderer.color = Color.white;
    }
}
