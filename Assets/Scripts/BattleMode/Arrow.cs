using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character.Player.ArrowBattle;
using Load;
using ScreenEffect;
using TMPro;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Direction = Character.Player.ArrowBattle.Direction;

namespace BattleMode
{
  public partial class Arrow : MonoBehaviour
  {
    public static string code;

    public static string nextScene;

    public int maxCount;

    public int curCount;

    public float delay;

    public float speed;

    public int phase = 0;

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

    [SerializeField]
    private TextMeshProUGUI leftCountTMP;

    [SerializeField]
    private Count counter;

    private PhaseInfo phaseInfo;

    [NonSerialized]
    public bool isCharging;

    private int temp;

    private void Awake()
    {
      phaseInfo = FindObjectOfType<PhaseInfo>();
      poolManager = FindObjectOfType<ArrowEnemyPoolManager>();
      poolManager.onRelease += Enemy_OnReleased;

      if (string.IsNullOrEmpty(code))
        code = "start";
    }

    private void OnDestroy()
    {
      ArrowEnemy.onTakeDamage -= Enemy_OnReleased;
    }

    private void Start()
    {
    }

    public void StartPattern(string code)
    {
      spawnRoutines = patterns[code];
      phase = 0;
      Play(phase);
    }

    private void Enemy_OnReleased(ArrowEnemy obj)
    {
      curCount++;

      if (curCount == maxCount)
      {
        if (phase == spawnRoutines.Length - 1)
        {
          SceneLoader.Instance.Load
          (
            nextScene,
            new EffectOption(ScreenEffects.FadeOut),
            new EffectOption(ScreenEffects.FadeIn)
          );
        }
        else
        {
          Play(++phase);
        }
      }
    }

    public void Play(int index)
    {
      isCharging = true;
      temp = index;
      counter.StartCounting(3, () => phaseInfo.StartAnim());
    }

    public void Play2()
    {
      maxCount = GetMaxCount(spawnRoutines[temp]);
      curCount = 0;
      isCharging = false;
      StartCoroutine(PlayRoutine(spawnRoutines[temp]));
    }

    private int GetMaxCount(string routine)
    {
      return routine.Count(c => c == 'L' || c == 'R' || c == 'U' || c == 'D');
    }

    private void Update()
    {
      playerHpBar.maxValue = player.maxHp;
      playerHpBar.value = player.hp;

      if (isCharging)
      {
        leftCountBar.maxValue = counter.maxTime;
        leftCountBar.value = counter.time;
      }
      else
      {
        leftCountBar.maxValue = maxCount;
        leftCountBar.value = maxCount - curCount;
      }

      leftCountTMP.text =
        $"{maxCount - curCount}명 남음 - 페이즈 {phase + 1}";
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

        if (key.Contains('s'))
        {
          var s = key.Split('s')[1];
          if (float.TryParse(s, out var changeSpeed))
            speed = changeSpeed;
        }

        if (key.Contains('d'))
        {
          var s = key.Split('d')[1];
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
