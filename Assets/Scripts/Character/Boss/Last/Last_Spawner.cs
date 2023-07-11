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
    private Last_Bgm last_bgm;
    [SerializeField]
    private GameObject Boss_Text;
    [SerializeField]
    private GameObject panelBossHp;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private int maxEnemyCount = 100;

    private void Awake()
    {
        Boss_Text.SetActive(false);
        panelBossHp.SetActive(false);
        boss.SetActive(false);
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;

        while ( true )
        {
           float positionX = Random.Range(screenData.LimitMin.x, screenData.LimitMax.x);
           Vector3 position = new Vector3(positionX, screenData.LimitMax.y+1.0f, 0.0f);
           GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
           SpawnEnemyHpSlider(enemyClone);

           currentEnemyCount++;
           if (currentEnemyCount == maxEnemyCount)
           {
                  StartCoroutine("SpawnBoss");
                  break;
           }
           yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHpSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHpPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;
    }

    private IEnumerator SpawnBoss()
    {
        last_bgm.BossBgm(BGMType.Boss);
        Boss_Text.SetActive(true);
        var sc = GameObject.Find("ScreenColor").GetComponent<Animator>();
        sc.Play("Effect");
        yield return new WaitForSeconds(3.0f);
        Boss_Text.SetActive(false);
        panelBossHp.SetActive(true);
        boss.SetActive(true);
        boss.GetComponent<Last_BossManager>().ChangeState(BossState.MoveBossPoint);
    }
}
