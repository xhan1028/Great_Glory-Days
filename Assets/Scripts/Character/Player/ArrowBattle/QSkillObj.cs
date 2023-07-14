using System;
using Pool;
using UnityEngine;

namespace Character.Player.ArrowBattle
{
  public class QSkillObj : PoolObject<QSkillObj>
  {
    public float speed = 2f;

    private float time;
    
    private void FixedUpdate()
    {
      transform.Translate(Vector3.up * Time.fixedDeltaTime * speed);
      time += Time.fixedUnscaledDeltaTime;
      if (time >= despawnTime)
      {
        Release();
      }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.transform.CompareTag("Enemy"))
      {
        col.GetComponent<ArrowEnemy>().TakeDamage();
      }
    }

    public override void OnGet()
    {
      base.OnGet();
      time = 0f;
    }
  }
}
