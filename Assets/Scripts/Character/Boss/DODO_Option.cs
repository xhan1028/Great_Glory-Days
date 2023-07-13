using Audio;
using Particle;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Character.Boss
{
  public class DODO_Option : Boss_Option
  {
    public override void TakeDamage(int damage)
    {
      health -= damage;
      bloodPoolManager.Get(obj => obj.transform.position = transform.position);
      AudioManager.Instance.PlaySFX("blood" + Random.Range(1, 4));

      animator.SetTrigger("Hurt");

      //if(health <= 280)
      //  {
      // GetComponent<Animator>().SetBool("IsThree", true);
      // }

      if (health <= 200)
      {
        GetComponent<Animator>().SetBool("IsTwo", true);
      }

      if (health <= 0)
      {
        Die();
      }
    }
  }
}
