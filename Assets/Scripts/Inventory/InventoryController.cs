using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Player;
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

        if(inventoryIsOpen == true)
        {
            //Cursor.lockState = CursorLockMode.None;
            transform.GetComponent<PlayerMovement>().enabled = false;
            transform.GetComponent<ThrowableSeeds>().enabled = false;
            transform.GetComponent<GetWater>().enabled = false;
        }
        else if (inventoryIsOpen == false)
        {
            //Cursor.lockState = CursorLockMode.Locked;
            //transform.GetComponent<PlayerMovement>().enabled = true;
            //transform.GetComponent<ThrowableSeeds>().enabled = true;
            //transform.GetComponent<GetWater>().enabled = true;
        }
    }
}
