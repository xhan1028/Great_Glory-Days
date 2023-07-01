using System;
using System.Collections;
using UnityEngine;
using Utility;

namespace Character.Player
{
  public class PlayerAttackController : MonoBehaviour
  {
    [Header("Components")]
    [SerializeField]
    private Animator targetAnimator;

    [SerializeField]
    private PlayerMovement movement;

    [Header("Attack")]
    [SerializeField]
    private float curCoolDown;

    private float beCoolDown;

    [SerializeField]
    private float curEndTime;

    private bool isCoolDowned;

    [SerializeField]
    private byte currentAttackIndex;

    public AttackData[] attackDatas;

    private Coroutiner<float, BoxCollider2D> attackCoroutine;

    private void Awake()
    {
      attackCoroutine = new Coroutiner<float, BoxCollider2D>(this, AttackDelayRoutine);
    }

    public void Attack()
    {
      if (curCoolDown > 0 || curEndTime > 0) return;

      isCoolDowned = false;
      var curData = attackDatas[currentAttackIndex];
      curEndTime = curData.endTime;
      beCoolDown = curData.cooldownTime;
      targetAnimator.SetTrigger(curData.animationParameter);
      targetAnimator.SetBool("isAttacking", true);
      attackCoroutine.Start(curData.attackDelay, curData.hitBoxCollider);
      movement.canFlip = false;
      
      currentAttackIndex = (byte) ((currentAttackIndex == attackDatas.Length - 1) ? 0 : currentAttackIndex + 1);
    }

    private IEnumerator AttackDelayRoutine(float delay, BoxCollider2D hitBox)
    {
      yield return new WaitForSeconds(delay);
      AttackEnemy(hitBox);
    }

    private void Update()
    {
      if (curCoolDown > 0)
      {
        curCoolDown -= Time.deltaTime;
      }

      if (curEndTime > 0)
      {
        curEndTime -= Time.deltaTime;
      }
      else if (!isCoolDowned)
      {
        isCoolDowned = true;
        curCoolDown = beCoolDown;
        targetAnimator.SetBool("isAttacking", false);
        movement.canFlip = true;
      }
    }

    private void AttackEnemy(BoxCollider2D hitBox)
    {
      // todo
    }
  }
}
