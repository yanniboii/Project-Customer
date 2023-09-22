using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{

    [SerializeField] List<InventoryItem> inventoryItems = new List<InventoryItem>();
    [SerializeField] List<InventorySlot> inventorySlots = new List<InventorySlot>();

    ThrowableSeeds throwableSeeds;

    // Start is called before the first frame update
    void Start()
    {
        throwableSeeds = FindObjectOfType<ThrowableSeeds>();
    }

    void CheckItem(int slotNumber)
    {
        if (inventorySlots[slotNumber].transform.childCount != 0)
        {
            int num = inventorySlots[slotNumber].GetComponentInChildren<InventoryItem>().itemNumber;
            Debug.Log(inventorySlots[slotNumber].GetComponentInChildren<InventoryItem>().itemNumber);
            throwableSeeds.SetEveryPlantFalse(); // Reset all plant variables

            // Determine which plant type to set based on the slot number
            switch (num)
            {
                case 0:
                    throwableSeeds.isGrass = true;
                    break;
                case 1:
                    throwableSeeds.isFern = true;
                    break;
                case 2:
                    throwableSeeds.isMush = true;
                    break;
                case 3:
                    throwableSeeds.isBerry = true;
                    break;
                case 4:
                    throwableSeeds.isBramble = true;
                    break;
                case 5:
                    throwableSeeds.isHolly = true;
                    break;
                case 6:
                    throwableSeeds.isLavender = true;
                    break;
                case 7:
                    throwableSeeds.isOak = true;
                    break;
                case 8:
                    throwableSeeds.isAsh = true;
                    break;
                case 9:
                    throwableSeeds.isHazel = true;
                    break;
                case 10:
                    throwableSeeds.isBirch= true;
                    break;
                case 11:
                    throwableSeeds.isMoss= true;
                    break;
                    /* Add more cases for additional slots if needed */
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Hi");

            CheckItem(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CheckItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CheckItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CheckItem(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            CheckItem(6);
        }
    }
}
