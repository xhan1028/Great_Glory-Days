using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject Player_AttackPrefab;
    [SerializeField]
    private float attackRate = 0.1f;
    [SerializeField]
    private int maxAttackLevel = 3;
    private int attackLevel = 1;

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while ( true )
        {
            // Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
            LevelAttack();

            yield return new WaitForSeconds(attackRate);
        }
    }

    private void LevelAttack()
    {
        GameObject clonePlayerAttackPoint = null;

        switch ( attackLevel )
        {
            case 1:
                Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Player_AttackPrefab, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(Player_AttackPrefab, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 3:
                Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
                clonePlayerAttackPoint = Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
                clonePlayerAttackPoint.GetComponent<PlayerMovement>().MoveTo(new Vector3(-0.2f, 1, 0));
                clonePlayerAttackPoint = Instantiate(Player_AttackPrefab, transform.position, Quaternion.identity);
                clonePlayerAttackPoint.GetComponent<PlayerMovement>().MoveTo(new Vector3(0.2f, 1, 0));
                break;
        }
    }
}
