using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryBaseObj;
        
    private bool inventype = false;

    private void Update()
    {
        if (inventype == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                InventoryBaseObj.SetActive(true);
                inventype = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                InventoryBaseObj.gameObject.SetActive(false);
                inventype = false;
            }
        }
    }
}
