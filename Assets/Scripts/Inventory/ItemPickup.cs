using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Slot slot;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                slot.SetColor(255f);
                Destroy(collision.gameObject);
            }
        }
    }
}
