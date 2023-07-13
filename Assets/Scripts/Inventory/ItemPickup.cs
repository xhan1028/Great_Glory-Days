using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickIp : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                Destroy(collision);
            }
        }
    }
}
