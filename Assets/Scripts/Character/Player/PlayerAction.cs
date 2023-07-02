using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameManager gameManager;
    GameObject scanObject;
    public Vector2 direction;
    public LayerMask layermask;
    public float distance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && scanObject != null)
        {
            gameManager.Action(scanObject);
        }
        Debug.DrawRay(transform.position, Vector2.right * distance, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, Vector2.right, distance, layermask);

        if (hit.collider != null)
        {
            scanObject = hit.transform.gameObject;

        }
    }


}
