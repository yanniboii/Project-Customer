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

    void CheckItem(int number)
    {

            if (inventorySlots[number].transform.childCount != 0)
            {
                switch(inventoryItems.Count) 
                {
                    case 0:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isGrass = true;
                            break;
                        }
                    case 1:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isFern = true;
                            break;
                        }
                    case 2:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isMush = true;
                            break;
                        }
                    case 3:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isBerry = true;
                            break;
                        }
                    case 4:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isBramble = true;
                            break;
                        }
                    case 5:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isHolly = true;
                            break;
                        }
                    case 6:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isLavender = true;
                            break;
                        }
                    case 7:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isOak = true;
                            break;
                        }
                    case 8:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isAsh = true;
                            break;
                        }
                    case 9:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isHazel = true;
                            break;
                        }
                    /*case 10:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isBirch = true;
                            break;
                        }
                    case 11:
                        {
                            throwableSeeds.SetEveryPlantFalse();
                            throwableSeeds.isMoss = true;
                            break;
                        }*/

                
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
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
