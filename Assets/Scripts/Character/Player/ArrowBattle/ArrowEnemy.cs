using System;
using System.Collections;
using BattleMode;
using Pool;
using UnityEngine;

namespace Character.Player.ArrowBattle
{
  public class ArrowEnemy : PoolObject<ArrowEnemy>
  {
    public float speed = 3f;
    public bool walking = true;

    [SerializeField]
    private ParticleSystem particle;

    private Animator anim;

    private Arrow arrowManager;
    
    private bool isDied;

    private void Awake()
    {
      anim = GetComponent<Animator>();
      arrowManager = FindObjectOfType<Arrow>();
    }

    public void TakeDamage()
    {
      // Release();
      isDied = true;
      anim.Play("Die");
    }

    public void FixedUpdate()
    {
      if (!walking) return;
      if (!isDied) 
        anim.Play("Walking");
      transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if (isDied) return;
      if (col.transform.CompareTag("Player"))
      {
        arrowManager.player.TakeDamage();
        Release();
      }
    }

    public void PlayParticle()
    {
      particle.Play();
    }

    public override void OnGetAfter()
    {
      base.OnGetAfter();
      isDied = false;
      anim.Play("None");
    }
  }
}
