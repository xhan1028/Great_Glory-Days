using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAction : MonoBehaviour
{
  [FormerlySerializedAs("gameManager")]
  public ChatManager chatManager;

  GameObject scanObject;
  public Vector2 direction;
  public LayerMask layermask;
  public float distance;

  private void Awake()
  {
    chatManager = FindObjectOfType<ChatManager>();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.F) && scanObject != null)
    {
      chatManager.Action(scanObject);
    }

    Debug.DrawRay(transform.position, Vector2.right * distance, Color.green);
    RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, Vector2.right, distance, layermask);

    if (hit.collider is not null)
    {
      scanObject = hit.transform.gameObject;
    }
    else
    {
      scanObject = null;
    }
  }
}