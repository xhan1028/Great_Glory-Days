using System;
using System.Collections;
using Audio;
using UnityEngine;

namespace Character.Player.Last_Boss
{
  public class PlayerWeapon : MonoBehaviour
  {
    [SerializeField]
    private GameObject Player_AttackPrefab;

    [SerializeField]
    private float attackRate = 0.1f;

    [SerializeField]
    private int maxAttackLevel = 3;

    private int attackLevel = 1;

    private float curCooldown;

    private Animator animator;
    public int AttackLevel
    {
      set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
      get => attackLevel;
    }

    private PlayerAttackPoolManager poolManager;

    private void Awake()
    {
      poolManager = FindObjectOfType<PlayerAttackPoolManager>();
      animator = GetComponent<Animator>();
    }

    // public void StartFiring()
    // {
    //   StartCoroutine("TryAttack");
    // }
    //
    // public void StopFiring()
    // {
    //   StopCoroutine("TryAttack");
    // }

    // private IEnumerator TryAttack()
    // {
    //   while (true)
    //   {
    //     // Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
    //     LevelAttack();
    //
    //     yield return new WaitForSeconds(attackRate);
    //   }
    // }

    public void TryAttack()
    {
      if (curCooldown >= attackRate)
      {
        curCooldown = 0f;
        LevelAttack();
      }
    }

    private void Update()
    {
      if (curCooldown < attackRate)
      {
        curCooldown += Time.deltaTime;
      }
    }

    private void LevelAttack()
    {
      // GameObject clonePlayerAttackPoint = null;
      AudioManager.Instance.PlaySFX("slash");
      animator.SetTrigger("attack");
      switch (attackLevel)
      {
        case 1:
        {
          // Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
          poolManager.Get(obj =>
          {
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.Euler(0f,0f, transform.rotation.z);
          });
          break;
        }
        
        case 2:
        {
          // Instantiate(Player_AttackPrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
          // Instantiate(Player_AttackPrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
          poolManager.Get(obj =>
          {
            obj.transform.position = transform.position + Vector3.left * 0.5f;
            obj.transform.rotation = Quaternion.Euler(0f,0f, transform.rotation.z);
          });
          
          poolManager.Get(obj =>
          {
            obj.transform.position = transform.position + Vector3.right * 0.5f;
            obj.transform.rotation = Quaternion.Euler(0f,0f, transform.rotation.z);
          });
          break;
        }

        case 3:
        {
          // Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
          // clonePlayerAttackPoint = Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
          // clonePlayerAttackPoint.GetComponent<PlayerMovement>().MoveTo(new Vector3(-0.2f, 1, 0));
          // clonePlayerAttackPoint = Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
          // clonePlayerAttackPoint.GetComponent<PlayerMovement>().MoveTo(new Vector3(0.2f, 1, 0));
          
          poolManager.Get(obj =>
          {
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.Euler(0f,0f, transform.rotation.z);
            obj.GetComponent<PlayerMovement>().MoveTo(new Vector3(-0.2f, 1, 0));
          });
          
          poolManager.Get(obj =>
          {
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.Euler(0f,0f, transform.rotation.z);
            obj.GetComponent<PlayerMovement>().MoveTo(new Vector3(0.2f, 1, 0));
          });
          break;
        }
      }
    }
  }
}
