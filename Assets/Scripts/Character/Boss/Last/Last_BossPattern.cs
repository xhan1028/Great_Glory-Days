using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public enum AttackType { LastBossWeapon = 0, LastBossCenterAttack }

public class Last_BossPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject BossAttackPrefab;

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
        float attackRate = 1.0f;
        int count = 23;
        float intervalAngle = 360 / count; // 보스 발사체 사이의 각도
        float weightAngle = 0; // 같은 위치로 발사되지 않게 설정

        while (true)
        {
            AudioManager.Instance.PlaySFX("explosion");
            for(int i = 0; i<count; ++i)
            {
                GameObject clone = Instantiate(BossAttackPrefab, transform.position, Quaternion.identity);
                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                clone.GetComponent<PlayerMovement>().MoveTo(new Vector2(x, y));
            }

            weightAngle += 1;

            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator LastBossCenterAttack()
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.1f;

        while(true)
        {
            AudioManager.Instance.PlaySFX("lazer1");
            GameObject clone = Instantiate(BossAttackPrefab, transform.position, Quaternion.identity);
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            clone.GetComponent<PlayerMovement>().MoveTo(direction);
            yield return new WaitForSeconds(attackRate);
        }
    }
}
