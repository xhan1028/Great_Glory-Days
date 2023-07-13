using System;
using System.Collections;
using Audio;
using Character.Objects;
using UnityEngine;

namespace Character.Boss.Last
{
  public enum AttackType
  {
    LastBossWeapon = 0, LastBossCenterAttack
  }

  public class Last_BossPattern : MonoBehaviour
  {
    // [SerializeField]
    // private GameObject BossAttackPrefab;

    private LastBossDamageObjPoolManager poolManager;

    private void Awake()
    {
      poolManager = FindObjectOfType<LastBossDamageObjPoolManager>();
    }

    public void StartFiring(AttackType attackType)
    {
      StartCoroutine(attackType.ToString());
    }

    public void StopFiring(AttackType attackType)
    {
      StopCoroutine(attackType.ToString());
    }

    private IEnumerator LastBossWeapon()
    {
      float attackRate = 0.76f;
      int count = 17;
      float intervalAngle = 360 / count; // 보스 발사체 사이의 각도
      float weightAngle = 0; // 같은 위치로 발사되지 않게 설정

      while (true)
      {
        AudioManager.Instance.PlaySFX("explosion");
        for (int i = 0; i < count; ++i)
        {
          // GameObject clone = Instantiate(BossAttackPrefab, transform.position, Quaternion.identity);
          poolManager.Get(obj =>
          {
            obj.transform.position = transform.position;
            float angle = weightAngle + intervalAngle * i;
            float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
            obj.GetComponent<PlayerMovement>().MoveTo(new Vector2(x, y) * 0.4f);
          });
        }

        weightAngle += 1;

        yield return new WaitForSeconds(attackRate);
      }
    }

    private IEnumerator LastBossCenterAttack()
    {
      Vector3 targetPosition = Vector3.zero;
      float attackRate = 0.1f;

      while (true)
      {
        AudioManager.Instance.PlaySFX("lazer1");
        // GameObject clone = Instantiate(BossAttackPrefab, transform.position, Quaternion.identity);
        poolManager.Get(obj =>
        {
          obj.transform.position = transform.position;
          Vector3 direction = (targetPosition - obj.transform.position).normalized;
          obj.GetComponent<PlayerMovement>().MoveTo(direction);
        });

        yield return new WaitForSeconds(attackRate);
      }
    }
  }
}
