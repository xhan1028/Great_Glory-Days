using System;
using Audio;
using Particle;
using Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Character.Boss.Last
{
  public class Last_Enemy : MonoBehaviour
  {
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private GameObject Death_effectPrefab;

    [SerializeField]
    private GameObject[] itemPrefabs;

    private ParticlePoolManager bloodPoolManager;

    private void Awake()
    {
      bloodPoolManager = FindObjectOfType<ParticlePoolManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("Player"))
      {
        collision.GetComponent<PlayerHp>().TakeDamage(damage);
        OnDie(false);
      }
    }

    public void OnDie(bool blood = true)
    {
      // Instantiate(Death_effectPrefab, transform.position, Quaternion.identity);
      if (blood)
      {
        bloodPoolManager.Get(obj => obj.transform.position = transform.position);
        AudioManager.Instance.PlaySFX("blood" + Random.Range(1, 4));
      }

      Destroy(gameObject);
      SpawnItem();
    }

    private void SpawnItem()
    {
      // 레벨업 5% / 회복 17%
      int spawnItem = Random.Range(0, 100);
      if (spawnItem < 5)
      {
        Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
      }
      else if (spawnItem < 22)
      {
        Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
      }
    }
  }
}
