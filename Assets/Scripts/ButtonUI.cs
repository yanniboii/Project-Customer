using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    ThrowableSeeds throwableSeeds;
    MoneyUI moneyUI;
    // Start is called before the first frame update
    void Start()
    {
        moneyUI = FindObjectOfType<MoneyUI>();
        throwableSeeds = FindObjectOfType<ThrowableSeeds>();
    }

    public void UnlockLavender(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 25 && !throwableSeeds.lavenderUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.lavenderUnlocked = true;
            moneyUI.money -= 25;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void UnlockMoss(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 60 && !throwableSeeds.mossUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.mossUnlocked = true;
            moneyUI.money -= 60;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            // If an Image component is found, disable it
            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void UnlockMushroom(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 130 && !throwableSeeds.mushUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.mushUnlocked = true;
            moneyUI.money -= 130;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            // If an Image component is found, disable it
            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void UnlockHolly(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 45 && !throwableSeeds.hollyUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.hollyUnlocked = true;
            moneyUI.money -= 45;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            // If an Image component is found, disable it
            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void UnlockBerry(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 80 && !throwableSeeds.berryUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.berryUnlocked = true;
            moneyUI.money -= 80;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            // If an Image component is found, disable it
            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void UnlockFern(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 200 && !throwableSeeds.fernUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.fernUnlocked = true;
            moneyUI.money -= 200;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            // If an Image component is found, disable it
            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void UnlockHazel(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 60 && !throwableSeeds.hazelUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.hazelUnlocked = true;
            moneyUI.money -= 60;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            // If an Image component is found, disable it
            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void UnlockOak(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 100 && !throwableSeeds.oakUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.oakUnlocked = true;
            moneyUI.money -= 100;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            // If an Image component is found, disable it
            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void UnlockAsh(InventoryItem inventoryItem)
    {
        if (moneyUI.money >= 300 && !throwableSeeds.ashUnlocked)
        {
            inventoryItem.transform.gameObject.SetActive(true);
            throwableSeeds.ashUnlocked = true;
            moneyUI.money -= 300;
            Image childImage = null;
            foreach (Transform child in transform)
            {
                childImage = child.GetComponent<Image>();
                if (childImage != null)
                {
                    break;
                }
            }

            // If an Image component is found, disable it
            if (childImage != null)
            {
                childImage.enabled = false;
            }
        }
    }
    public void Unlock()
    {
        throwableSeeds.lavenderUnlocked = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
