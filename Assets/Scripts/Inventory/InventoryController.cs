using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public KeyCode openCloseKey = KeyCode.I;
    public bool inventoryIsOpen = false;  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(openCloseKey))
        {
            inventoryIsOpen = !inventoryIsOpen;
            Inventory.SetActive(inventoryIsOpen);
        }
    }
}
