using System;
using Audio;
using BattleMode;
using Cinema;
using Load;
using Particle;
using ScreenEffect;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Character.Boss
{
  public class Boss_Option : MonoBehaviour
  {
    public string type;

    public Animator animator;

    public int health = 500;
    //  int currentHealth;

    //void Start()
    //{
    //currentHealth = maxHealth;
    // }

    [SerializeField]
    protected ParticlePoolManager bloodPoolManager;

    public virtual void TakeDamage(int damage)
    {
      health -= damage;
      bloodPoolManager.Get(obj => obj.transform.position = transform.position);
      AudioManager.Instance.PlaySFX("blood" + Random.Range(1, 4));

      animator.SetTrigger("Hurt");

      if (health <= 0)
      {
        Die();
      }
    }

    private void Start()
    {
      
    }

    protected virtual void Die()
    {
      Debug.Log("dead");

      animator.SetBool("IsDead", true);

      GetComponent<Collider2D>().enabled = false;
      this.enabled = false;

      LoadNext();
    }

    protected void LoadNext()
    {
      if (Arrow.arrowData.ContainsKey(type))
      {
        var data = Arrow.arrowData[type];
        Arrow.code = data.code;
        Arrow.nextScene = data.nextScene;
        SceneLoader.Instance.Load
        (
          "ArrowMode",
          new EffectOption(ScreenEffects.FadeOut),
          new EffectOption(ScreenEffects.FadeIn)
        );
      }
      else if (Arrow.cinemaData.ContainsKey(type))
      {
        var data = Arrow.cinemaData[type];
        
        CinemaManager.Instance.Play(data.code, data.nextScene);
      }
    }
  }
}
