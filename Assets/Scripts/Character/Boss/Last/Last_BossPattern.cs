using System.Collections;
using System.Collections.Generic;
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
        float attackRate = 0.5f;
        int count = 30;
        float intervalAngle = 360 / count; // ���� �߻�ü ������ ����
        float weightAngle = 0; // ���� ��ġ�� �߻���� �ʰ� ����

        while (true)
        {
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
            GameObject clone = Instantiate(BossAttackPrefab, transform.position, Quaternion.identity);
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            clone.GetComponent<PlayerMovement>().MoveTo(direction);
            yield return new WaitForSeconds(attackRate);
        }
    }
}