using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 50;
    private float currentHp;
    private SpriteRenderer spriterenderer;

    public float MaxHp => maxHp;
    public float CurrentHp
    {
        set => currentHp = Mathf.Clamp(value, 0, maxHp);
        get => currentHp;
    }

    private void Awake()
    {
        currentHp = maxHp;
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        if ( currentHp <= 0 )
        {
            Debug.Log("플레이어 체력 : 0");
        }
    }

    private IEnumerator HitColorAnimation()
    {
        spriterenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriterenderer.color = Color.white;
    }

  //  public void GoodBye()
  //  {
      //  if ( currentHp < 0 )
       // {
      //      DieScene();
      //  }
  //  }

   // public void DieScene()
   // {
    //    SceneManager.LoadScene("Die");
 //   }
}
