using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Utility;

public class Player_Battles : MonoBehaviour
{
  public Animator animator;

  public Transform attackPoint;
  public float attackRange = 0.5f;
  public LayerMask enemyLayers;

  public int attackDamage = 40;
  public float attackRate = 2f;
  float nextAttackTime = 0f;

  Boss_Option boss_option;

  [SerializeField]
  private float atkEndTime;

  [SerializeField]
  private float curEndTime;

  [SerializeField]
  private byte currentAttackIndex;

  [SerializeField]
  private byte maxAttack = 2;

  private void Awake()
  {
    ScreenClick.Instance.onPointClick += ScreenClick_OnPointClick;
  }

  private void ScreenClick_OnPointClick(PointerEventData eventdata)
  {
    if (curEndTime <= 0)
    {
      Attack();
    }
  }

  public void Attack()
  {
    if (curEndTime > 0) return;

    curEndTime = atkEndTime;
    animator.SetTrigger($"Attack_Player{currentAttackIndex}");
    animator.SetBool("IsAttacking", true);
    Attack_Player();

    currentAttackIndex = (byte)((currentAttackIndex == maxAttack - 1) ? 0 : currentAttackIndex + 1);
  }


  private void Update()
  {
    // if (Time.time >= nextAttackTime)
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Attack_Player();
    //         nextAttackTime = Time.time + 1f / attackRate;
    //     }
    // }

    // if (Input.GetKeyDown(KeyCode.Space) && curEndTime <= 0)
    // {
    //   Attack();
    // }

    if (curEndTime > 0)
    {
      curEndTime -= Time.deltaTime;
    }
    else
    {
      animator.SetBool("IsAttacking", false);
    }
  }

  private void Attack_Player()
  {
    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

    foreach (Collider2D boss_option in hitEnemies)
    {
      boss_option.GetComponent<Boss_Option>().TakeDamage(attackDamage);
    }
  }

  private void OnDrawGizmosSelected()
  {
    if (attackPoint == null)
      return;

    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  }
}