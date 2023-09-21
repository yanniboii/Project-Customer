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

    public void UnlockLavender()
    {
        if (moneyUI.money >= 25 && !throwableSeeds.lavenderUnlocked)
        {
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
    public void UnlockMoss()
    {
        if (moneyUI.money >= 60 && !throwableSeeds.mossUnlocked)
        {
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
    public void UnlockMushroom()
    {
        if (moneyUI.money >= 130 && !throwableSeeds.mushUnlocked)
        {
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
    public void UnlockHolly()
    {
        if (moneyUI.money >= 45 && !throwableSeeds.hollyUnlocked)
        {
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
    public void UnlockBerry()
    {
        if (moneyUI.money >= 80 && !throwableSeeds.berryUnlocked)
        {
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
    public void UnlockFern()
    {
        if (moneyUI.money >= 200 && !throwableSeeds.fernUnlocked)
        {
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
    public void UnlockHazel()
    {
        if (moneyUI.money >= 60 && !throwableSeeds.hazelUnlocked)
        {
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
    public void UnlockOak()
    {
        if (moneyUI.money >= 100 && !throwableSeeds.oakUnlocked)
        {
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
    public void UnlockAsh()
    {
        if (moneyUI.money >= 300 && !throwableSeeds.ashUnlocked)
        {
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
