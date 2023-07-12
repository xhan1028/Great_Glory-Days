using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveBossPoint = 0, Phase01, Phase02, Phase03 }

public class Last_BossManager : MonoBehaviour
{
	[SerializeField]
	private Screen_Data scrrendata;
	[SerializeField]
	private float BossPoint = 3f;
	private BossState bossState = BossState.MoveBossPoint;
	private PlayerMovement PMovement;
	private Last_BossPattern Lbosspattern;
	private Last_Hp lasthp;

	private void Awake()
	{
		PMovement = GetComponent<PlayerMovement>();
		Lbosspattern = GetComponent<Last_BossPattern>();
		lasthp = GetComponent<Last_Hp>();
	}

	public void ChangeState(BossState newState)
	{
		StopCoroutine(bossState.ToString());
		bossState = newState;
		StartCoroutine(bossState.ToString());
	}

	private IEnumerator MoveBossPoint()
	{
		PMovement.MoveTo(Vector3.down);

		while(true)
		{
			if(transform.position.y <= BossPoint)
			{
				PMovement.MoveTo(Vector3.zero);
				ChangeState(BossState.Phase01);
			}

			yield return null;
		}
	}

	private IEnumerator Phase01()
	{
		Lbosspattern.StartFiring(AttackType.LastBossWeapon);

		while (true)
		{
			if (lasthp.CurrentHP <= lasthp.MaxHP * 0.8f)
			{
				Lbosspattern.StopFiring(AttackType.LastBossWeapon);
				ChangeState(BossState.Phase02);
			}
			yield return null;
		}
	}

	private IEnumerator Phase02()
	{
		Lbosspattern.StartFiring(AttackType.LastBossCenterAttack);
		Vector3 direction = Vector3.right;
		PMovement.MoveTo(direction);

		while (true)
		{
			if(transform.position.x <= scrrendata.LimitMin.x || transform.position.x >= scrrendata.LimitMax.x)
			{
				direction *= -1;
				PMovement.MoveTo(direction);
			}
			if (lasthp.CurrentHP <= lasthp.MaxHP * 0.3f)
			{
				Lbosspattern.StopFiring(AttackType.LastBossCenterAttack);
				ChangeState(BossState.Phase03);
			}
			yield return null;
		}
	}

	private IEnumerator Phase03()
	{
		Lbosspattern.StartFiring(AttackType.LastBossWeapon);
		Lbosspattern.StartFiring(AttackType.LastBossCenterAttack);

		Vector3 direction = Vector3.left;
		PMovement.MoveTo(direction);

		while ( true )
		{
			if(transform.position.x <= scrrendata.LimitMin.x || transform.position.x >= scrrendata.LimitMax.x)
			{
				direction *= -1;
				PMovement.MoveTo(direction);
			}
			yield return null;
		}
	}
}
