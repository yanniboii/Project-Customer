using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (moneyUI.money >= 25)
        {
            throwableSeeds.lavenderUnlocked = true;
            moneyUI.money -= 25;
        }
    }
    public void UnlockMoss()
    {
        if (moneyUI.money >= 60)
        {
            throwableSeeds.mossUnlocked = true;
            moneyUI.money -= 60;
        }
    }
    public void UnlockMushroom()
    {
        if (moneyUI.money >= 130)
        {
            throwableSeeds.mushUnlocked = true;
            moneyUI.money -= 130;
        }
    }
    public void UnlockHolly()
    {
        if (moneyUI.money >= 45)
        {
            throwableSeeds.hollyUnlocked = true;
            moneyUI.money -= 45;
        }
    }
    public void UnlockBerry()
    {
        if (moneyUI.money >= 80)
        {
            throwableSeeds.berryUnlocked = true;
            moneyUI.money -= 80;
        }
    }
    public void UnlockFern()
    {
        if (moneyUI.money >= 200)
        {
            throwableSeeds.fernUnlocked = true;
            moneyUI.money -= 200;
        }
    }
    public void UnlockHazel()
    {
        if (moneyUI.money >= 60)
        {
            throwableSeeds.hazelUnlocked = true;
            moneyUI.money -= 60;
        }
    }
    public void UnlockOak()
    {
        if (moneyUI.money >= 100)
        {
            throwableSeeds.oakUnlocked = true;
            moneyUI.money -= 100;
        }
    }
    public void UnlockAsh()
    {
        if (moneyUI.money >= 300)
        {
            throwableSeeds.ashUnlocked = true;
            moneyUI.money -= 300;
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
