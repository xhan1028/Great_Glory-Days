using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject InventoryBaseObj;
        
    public bool inventype = false;

    private void Update()
    {
        if (inventype == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                InventoryBaseObj.gameObject.SetActive(true);
                inventype = true;
            }
        }

        if (inventype == true)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                InventoryBaseObj.gameObject.SetActive(false);
                inventype = false;
            }
        }
    }
}
