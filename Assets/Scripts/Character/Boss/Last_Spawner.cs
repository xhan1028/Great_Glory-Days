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
    private GameObject enemyHpPrefab;
    [SerializeField]
    private Transform canvasTransform;
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
           Vector3 position = new Vector3(positionX, screenData.LimitMax.y+1.0f, 0.0f);
           GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
           SpawnEnemyHpSlider(enemyClone);
           yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHpPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;
    }
}
