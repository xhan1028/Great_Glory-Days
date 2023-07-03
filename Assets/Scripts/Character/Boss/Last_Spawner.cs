using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Spawner : MonoBehaviour
{
    [SerializeField]
    private Screen_Data screenData;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnTime;

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while ( true )
        {
           float positionX = Random.Range(screenData.LimitMin.x, screenData.LimitMax.x);
           Instantiate(enemyPrefab, new Vector3(positionX, screenData.LimitMax.y+1.0f, 0.0f), Quaternion.identity);
           yield return new WaitForSeconds(spawnTime);
        }
    }

}
