using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character.Player.ArrowBattle;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleMode
{
  public class Arrow : MonoBehaviour
  {
    public int maxCount;

    public int curCount;

    public float delay;
    
    public float speed;

    [SerializeField]
    private Transform[] spawnLocate;

    private ArrowEnemyPoolManager poolManager;

    public ArrowPlayer player;

    [Multiline]
    [SerializeField]
    private string[] spawnRoutines;

    [SerializeField]
    private ProgressBar playerHpBar;
    
    [SerializeField]
    private ProgressBar leftCountBar;
    
    [SerializeField]
    private ProgressBar waitBar;

    private void Awake()
    {
      poolManager = FindObjectOfType<ArrowEnemyPoolManager>();
      poolManager.onRelease += Enemy_OnReleased;
    }

    private void Start()
    {
      Play(2);
    }

    private void Enemy_OnReleased(ArrowEnemy obj)
    {
      curCount++;
    }

    public void Play(int index)
    {
      maxCount = GetMaxCount(spawnRoutines[index]);
      StartCoroutine(PlayRoutine(spawnRoutines[index]));
    }

    private int GetMaxCount(string routine)
    {
      return routine.Count(c => c == 'L' || c == 'R' || c == 'U' || c == 'D');
    }

    private void Update()
    {
      playerHpBar.maxValue = player.maxHp;
      playerHpBar.value = player.hp;
    }

    private IEnumerator PlayRoutine(string routine)
    {
      var keys = routine.Split(' ');

      foreach (var key in keys)
      {
        if (key.Contains('L'))
          SpawnEnemy(Direction.Left);
        if (key.Contains('R'))
          SpawnEnemy(Direction.Right);
        if (key.Contains('U'))
          SpawnEnemy(Direction.Up);
        if (key.Contains('D'))
          SpawnEnemy(Direction.Down);

        var removeKey = key.Replace("L", "").Replace("R", "").Replace("U", "").Replace("D", "");

        if (removeKey.Contains('s'))
        {
          var s = removeKey.Split('s')[1].Split('s')[0];
          if (float.TryParse(s, out var changeSpeed))
            speed = changeSpeed;
        }
        
        if (removeKey.Contains('d'))
        {
          var s = removeKey.Split('d')[1].Split('d')[0];
          if (float.TryParse(s, out var changeDelay))
            delay = changeDelay;
        }

        yield return new WaitForSeconds(delay);
      }
    }

    private void SpawnEnemy(float dir)
    {
      var obj = poolManager.Get(enemy =>
      {
        enemy.transform.position = spawnLocate[dir switch
        {
          Direction.Left  => 0,
          Direction.Right => 1,
          Direction.Up    => 2,
          Direction.Down  => 3,
        }].position;

        var r = enemy.transform.rotation;
        enemy.transform.rotation = Quaternion.Euler(r.x, r.y, dir);
        enemy.speed = speed;
      });
    }
  }
}
