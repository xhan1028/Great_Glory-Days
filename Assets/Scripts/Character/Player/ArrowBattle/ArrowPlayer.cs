using System;
using System.Collections.Generic;
using System.Linq;
using Audio;
using BattleMode;
using Manager;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Character.Player.ArrowBattle
{
  public class ArrowPlayer : MonoBehaviour
  {
    [SerializeField]
    private GameObject player;

    private Arrow manager;

    private QSkillObjPoolManager qSkillPoolManager;

    [SerializeField]
    private BoxCollider2D hitBox;

    public int hp;

    public int maxHp = 7;

    private Animator cameraAnimator;

    private Animator animator;

    public float cooldown = 0.1f;

    public float curCooldown;

    public Skill qSkill;

    public Skill eSkill;

    public float curZ;

    private Dictionary<KeyCode[], float> keyData = new()
    {
      { new[] { KeyCode.UpArrow, KeyCode.W }, Direction.Up },
      { new[] { KeyCode.DownArrow, KeyCode.S }, Direction.Down },
      { new[] { KeyCode.LeftArrow, KeyCode.A }, Direction.Left },
      { new[] { KeyCode.RightArrow, KeyCode.D }, Direction.Right }
    };

    private float GetAngle(KeyCode key)
    {
      return keyData[keyData.Keys.Where(list => list.Contains(key)).First()];
    }

    private void Update()
    {
      if (curCooldown > 0)
        curCooldown -= Time.deltaTime;

      if (Input.GetKeyDown(KeyCode.Q))
        qSkill.Use();

      if (Input.GetKeyDown(KeyCode.E))
        eSkill.Use();

      foreach (var data in keyData)
        foreach (var key in data.Key)
        {
          if (Input.GetKeyDown(key))
          {
            // var rotation = player.transform.rotation;
            // player.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, GetAngle(key));
            // animator.Play(GetAngle(key) switch
            // {
            //   Direction.Up    => "Up",
            //   Direction.Left  => "Left",
            //   Direction.Down  => "Down",
            //   Direction.Right => "Right",
            // });

            curZ = (int) GetAngle(key);
            animator.SetInteger("z", (int)curZ);
          }
        }
    }

    private void Awake()
    {
      manager = FindObjectOfType<Arrow>();
      qSkillPoolManager = FindObjectOfType<QSkillObjPoolManager>();

      // ScreenClick.Instance.onPointClick += ScreenClick_OnPointClick;
      cameraAnimator = FindObjectOfType<UnityEngine.Camera>().GetComponent<Animator>();
      animator = GetComponent<Animator>();
      hp = maxHp;

      qSkill.onUse = OnQSkill;
      eSkill.onUse = OnESkill;
    }

    private void OnESkill()
    {
      AudioManager.Instance.PlaySFX("arrow_qskill");

      qSkillPoolManager.Get(obj =>
      {
        obj.transform.position = player.transform.position;
        obj.transform.rotation = Quaternion.Euler(0f, 0f, curZ);
        Debug.Log(animator.GetFloat("z"));
      });
    }

    private void OnQSkill()
    {
      AudioManager.Instance.PlaySFX("arrow_qskill");
      for (var i = 0; i < 360; i += 90)
      {
        qSkillPoolManager.Get(obj =>
        {
          obj.transform.position = player.transform.position;
          obj.transform.rotation = Quaternion.Euler(0f, 0f, i);
        });
      }
    }

    // private void ScreenClick_OnPointClick(PointerEventData eventdata)
    // {
    //   Attack();
    // }

    public void Attack()
    {
      if (curCooldown > 0)
        return;
      curCooldown = cooldown;
      animator.SetTrigger("attack");
      var hit = Physics2D.OverlapBoxAll((Vector2) hitBox.transform.position + hitBox.offset, hitBox.size, 0f);

      if (hit.Length == 0) return;
      foreach (var obj in hit.Where(x => x.transform.CompareTag("Enemy")))
      {
        obj.GetComponent<ArrowEnemy>().TakeDamage();
      }
    }

    private void OnDestroy()
    {
      // ScreenClick.Instance.onPointClick -= ScreenClick_OnPointClick;
    }

    public void TakeDamage()
    {
      cameraAnimator.Play("Hurt" + Random.Range(1, 3));
      AudioManager.Instance.PlaySFX("hurt");
      hp--;

      if (hp <= 0)
      {
        GameManager.Instance.Die(manager.deadScene);
      }
    }

    public void PlaySwordSound()
    {
      AudioManager.Instance.PlaySFX("sword");
    }
  }
}
