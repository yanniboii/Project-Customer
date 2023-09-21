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
        playerMovement = FindObjectOfType<PlayerMovement>();
        throwableSeeds = FindObjectOfType<ThrowableSeeds>();
        getWater = FindObjectOfType<GetWater>();
        playerCam= FindObjectOfType<PlayerCam>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(openCloseKey))
        {
            inventoryIsOpen = !inventoryIsOpen;
            Inventory.SetActive(inventoryIsOpen);
            Debug.Log("Inventory Is Open: " + inventoryIsOpen);
        }

        if (inventoryIsOpen == true)
        {
            Debug.Log("Inventory is open - Cursor visible");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerCam.enabled = false;
            playerMovement.enabled = false;
            throwableSeeds.enabled = false;
            getWater.enabled = false;
        }
        else if (inventoryIsOpen == false)
        {
            Debug.Log("Inventory is closed - Cursor locked");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerCam.enabled = true;
            playerMovement.enabled = true;
            throwableSeeds.enabled = true;
            getWater.enabled = true;
        }

    }
}
