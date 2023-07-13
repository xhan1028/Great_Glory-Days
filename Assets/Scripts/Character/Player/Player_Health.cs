using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using Manager;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player_Health : MonoBehaviour
{
//	Image HealthBar;
  public int chr_health = 100;
  //chr_health health;

  public ProgressBar hpBar;

  private Animator cameraAnimator;
  
  private void Awake()
  {
    cameraAnimator = FindObjectOfType<UnityEngine.Camera>().GetComponent<Animator>();

    if (hpBar is not null)
    {
      hpBar.maxValue = chr_health;
      hpBar.value = chr_health;
    }
  }

  public void TakeDamage(int damage)
  {
    chr_health -= damage;
    
    if (hpBar is not null)
    {
      hpBar.value = chr_health;
    }

    StartCoroutine(DamageAnimation());
    
    AudioManager.Instance.PlaySFX("hurt");
    cameraAnimator.Play("Hurt" + Random.Range(1,3));

    if (chr_health <= 0)
    {
      Die();
    }
  }
//
//	void Start()
  // {
  // //  //   HealthBar = GetComponent<Image>();
  // }

//	void Update()
  //{
  //	HealthBar.fillAmount = chr_health;
  //}

  void Die()
  {
    // SceneManager.LoadScene("Die");
    GameManager.Instance.Die();
  }

  IEnumerator DamageAnimation()
  {
    SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

    for (int i = 0; i < 3; i++)
    {
      foreach (SpriteRenderer sr in srs)
      {
        Color c = sr.color;
        c.a = 0;
        sr.color = c;
      }

      yield return new WaitForSeconds(.1f);

      foreach (SpriteRenderer sr in srs)
      {
        Color c = sr.color;
        c.a = 1;
        sr.color = c;
      }

      yield return new WaitForSeconds(.1f);
    }
  }
}