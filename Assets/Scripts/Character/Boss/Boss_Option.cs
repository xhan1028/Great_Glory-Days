using System.Collections;
using System.Collections.Generic;
using Audio;
using Load;
using ScreenEffect;
using UnityEngine;

public class Boss_Option : MonoBehaviour
{
    public Animator animator;

    public int health = 500;
  //  int currentHealth;

    //void Start()
    //{
        //currentHealth = maxHealth;
   // }

    public void TakeDamage(int damage)
    {
        health -= damage;

        animator.SetTrigger("Hurt");

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("dead");

        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
        SceneLoader.Instance.Load
        (
            "ArrowMode",
            new EffectOption(ScreenEffects.FadeOut),
            new EffectOption(ScreenEffects.FadeIn),
            () =>
            {
                var arrowManager = FindObjectOfType<BattleMode.Arrow>();

                arrowManager.nextScene = "Last_Boss2";
                arrowManager.deadScene = "Home";
                arrowManager.StartPattern(new []
                {
                    "d0.5ds3s L R R U D  R L  U L D R U  U D L",
                    "d0.44ds3s U U  L L R L L U D   U D L U R L D U",
                    "d0.4ds3s RLUD R R R R L L U L L U L R  LR L U D L U RL D L U D L R DL U L"
                });
            }
        );
    }
}
