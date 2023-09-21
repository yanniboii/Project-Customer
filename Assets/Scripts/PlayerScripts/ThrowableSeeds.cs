using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSeeds : MonoBehaviour
{
    [Header("Variables")] //variables for player and object
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")] // variables for throwable settings
    public int totalThrows;
    public float cooldownThrows;

    [Header("Throws")] // variables for throwable physics
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;
    bool readyToThrow;

    public bool isGrass = false;
    public bool isFern = false;
    public bool isMush = false;
    public bool isBerry = false;
    public bool isBramble = false;
    public bool isHolly = false;
    public bool isLavender = false;
    public bool isOak = false;
    public bool isAsh = false;
    public bool isHazel = false;
    public bool isBirch = false;
    public bool isMoss = false;



    public bool fernUnlocked = false;
    public bool mushUnlocked = false;
    public bool berryUnlocked = false;
    public bool hollyUnlocked = false;
    public bool lavenderUnlocked = false;
    public bool oakUnlocked = false;
    public bool ashUnlocked = false;
    public bool hazelUnlocked = false;
    public bool mossUnlocked = false;

    MessageUI messageUI;

    public int GetSeedNumbers()
    {
        return totalThrows;
    }
    private void Start()
    {
        messageUI = FindObjectOfType<MessageUI>();
        readyToThrow = true;
    }

    private void Update()
    {
        //check if you can throw the object
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();

        }
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetEveryPlantFalse();
            isGrass = true;
            if(messageUI.messageIndex == 0)
            {
                messageUI.messageIndex++;
                messageUI.SetNewMessage();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && fernUnlocked)
        {
            SetEveryPlantFalse();
            isFern = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && mushUnlocked)
        {
            SetEveryPlantFalse();
            isMush = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && berryUnlocked)
        {
            SetEveryPlantFalse();
            isBerry = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetEveryPlantFalse();
            isBramble = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && hollyUnlocked)
        {
            SetEveryPlantFalse();
            isHolly = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) && lavenderUnlocked)
        {
            SetEveryPlantFalse();
            isLavender = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8) && oakUnlocked)
        {
            SetEveryPlantFalse();
            isOak = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9) && ashUnlocked)
        {
            SetEveryPlantFalse();
            isAsh = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0) && hazelUnlocked)
        {
            SetEveryPlantFalse();
            isHazel = true;
        }*/
    }

    public void SetEveryPlantFalse()
    {
        isGrass = false;
        isFern = false;
        isMush = false;
        isBerry = false;
        isBramble = false;
        isHolly = false;
        isLavender = false;
        isOak = false;
        isAsh = false;
        isHazel = false;
        if(messageUI.messageIndex== 5)
        {
            messageUI.messageIndex++;
            messageUI.SetNewMessage();
        }
    }
    private void Throw()
    {
        readyToThrow = false;
        if (messageUI.messageIndex == 1)
        {
            messageUI.messageIndex++;
            messageUI.SetNewMessage();
        }
        //initializing throwable object
        GameObject throwable = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        //get rb component for our throwable
        Rigidbody throwableRB = throwable.GetComponent<Rigidbody>();

        throwable.transform.parent = this.gameObject.transform;

        //correct direction of throwable
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        //add force to the throwable
        Vector3 forceAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        throwableRB.AddForce(forceAdd, ForceMode.Impulse); // we add the force once not the entire time

        totalThrows--; // subtract 1 from the total every time we throw

        Invoke(nameof(ResetThrow), cooldownThrows); //cd implementation
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
