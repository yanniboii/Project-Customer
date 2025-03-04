using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Player;
    public KeyCode openCloseKey = KeyCode.I;
    public bool inventoryIsOpen = false;
    

    PlayerMovement playerMovement;
    ThrowableSeeds throwableSeeds;
    GetWater getWater;
    PlayerCam playerCam;

    private void Start()
    {
        playerCam = FindObjectOfType<PlayerCam>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        throwableSeeds = FindObjectOfType<ThrowableSeeds>();
        getWater = FindObjectOfType<GetWater>();  
    }
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMovement.enabled = false;
            playerCam.enabled = false;
            throwableSeeds.enabled = false;
            getWater.enabled = false;
        }
        else if (inventoryIsOpen == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            playerMovement.enabled = true;
            playerCam.enabled = true;
            throwableSeeds.enabled = true;
            getWater.enabled = true;*/
            
            if (getWater.hasWateringCan == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                playerMovement.enabled = true;
                throwableSeeds.enabled = true;
                getWater.enabled = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                playerMovement.enabled = true;
                throwableSeeds.enabled = false;
                getWater.enabled = true;
            } 
        }
    }
}
