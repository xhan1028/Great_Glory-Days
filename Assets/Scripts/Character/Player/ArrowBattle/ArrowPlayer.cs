using System;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField]
    private BoxCollider2D hitBox;

    public int hp;

    public int maxHp = 5;

    private Animator cameraAnimator;

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
      foreach (var data in keyData)
        foreach (var key in data.Key)
        {
          if (Input.GetKeyDown(key))
          {
            var rotation = player.transform.rotation;
            player.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, GetAngle(key));
          }
        }
    }

    private void Awake()
    {
      ScreenClick.Instance.onPointClick += ScreenClick_OnPointClick;
      cameraAnimator = FindObjectOfType<UnityEngine.Camera>().GetComponent<Animator>();
      hp = maxHp;
    }

    private void ScreenClick_OnPointClick(PointerEventData eventdata)
    {
      Attack();
    }

    private void Attack()
    {
      var hit = Physics2D.OverlapBoxAll((Vector2)hitBox.transform.position + hitBox.offset, hitBox.size, 0f);

      if (hit.Length == 0) return;
      foreach (var obj in hit.Where(x => x.transform.CompareTag("Enemy")))
      {
        obj.GetComponent<ArrowEnemy>().TakeDamage();
      }
    }

    private void OnDestroy()
    {
      ScreenClick.Instance.onPointClick -= ScreenClick_OnPointClick;
    }

    public void TakeDamage()
    {
      
      cameraAnimator.Play("Hurt" + Random.Range(1,3));
      hp--;

      if (hp <= 0)
      {
        GameManager.Instance.Die();
      }
    }
  }
}
