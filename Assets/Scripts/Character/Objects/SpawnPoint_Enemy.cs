using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Enemy : MonoBehaviour
{
	[SerializeField]
	private Screen_Data scrrenData;
	private float destroyWeight = 2.0f;

	private void LateUpdate()
	{
		if ( transform.position.y < scrrenData.LimitMin.y - destroyWeight ||
			 transform.position.y > scrrenData.LimitMax.y + destroyWeight ||
			 transform.position.x < scrrenData.LimitMin.x - destroyWeight ||
			 transform.position.x > scrrenData.LimitMax.x + destroyWeight )
		{
			Destroy(gameObject);
		}
	}
}
