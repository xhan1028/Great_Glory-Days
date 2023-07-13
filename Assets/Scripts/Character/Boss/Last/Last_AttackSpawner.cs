using System.Collections;
using UnityEngine;

namespace Character.Boss.Last
{
  public class Last_AttackSpawner : MonoBehaviour
  {
    [SerializeField]
    private Screen_Data scrrenData;

    [SerializeField]
    private GameObject Warn_LinePrefab;

    [SerializeField]
    private GameObject Enemy_AttackPrefab;

    [SerializeField]
    private float minSpawnTime = 1.0f;

    [SerializeField]
    private float maxSpawnTime = 4.0f;

    private void Awake()
    {
      StartCoroutine("SpawnAttack_Enemy");
    }

    private IEnumerator SpawnAttack_Enemy()
    {
      while (true)
      {
        float positionX = Random.Range(scrrenData.LimitMin.x, scrrenData.LimitMax.x);

        GameObject Warn_LineClone = Instantiate(Warn_LinePrefab, new Vector3(positionX, 0, 0), Quaternion.identity);

        yield return new WaitForSeconds(1.0f);
        Destroy(Warn_LineClone);

        Vector3 Enemy_AttackPosition = new Vector3(positionX, scrrenData.LimitMax.y + 1.0f, 0);
        Instantiate(Enemy_AttackPrefab, Enemy_AttackPosition, Quaternion.identity);

        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        yield return new WaitForSeconds(spawnTime);
      }
    }
  }
}
