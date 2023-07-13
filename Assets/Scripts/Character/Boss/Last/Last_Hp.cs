using System.Collections;
using Audio;
using Cinema;
using Particle;
using UnityEngine;

namespace Character.Boss.Last
{
  public class Last_Hp : MonoBehaviour
  {
    [SerializeField]
    private float maxHP = 500;

    private float currentHP;
    private SpriteRenderer spriterenderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private ParticlePoolManager bloodPoolManager;

    private void Awake()
    {
      currentHP = maxHP;
      spriterenderer = GetComponent<SpriteRenderer>();
      bloodPoolManager = FindObjectOfType<ParticlePoolManager>();
    }

    public void TakeDamage(float damage)
    {
      currentHP -= damage;

      StopCoroutine("HitColorAnimation");
      StartCoroutine("HitColorAnimation");
      
      bloodPoolManager.Get(obj => obj.transform.position = transform.position);
      AudioManager.Instance.PlaySFX("blood" + Random.Range(1, 4));

      if (currentHP <= 0)
      {
        // SceneManager.LoadScene("lastbossdie");
        CinemaManager.Instance.Play("LastBossDie", "Tobecontinued", false);
      }
    }

    private IEnumerator HitColorAnimation()
    {
      spriterenderer.color = Color.red;
      yield return new WaitForSeconds(0.05f);
      spriterenderer.color = Color.white;
    }
  }
}
