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

    public bool isGrass = true;
    public bool isFern = false;

    public int GetSeedNumbers()
    {
        return totalThrows;
    }
    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        //check if you can throw the object
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isGrass= true;
            isFern= false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            isGrass= false;
            isFern= true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isGrass = false;
            isFern = false;
        }
    }

    private void Throw()
    {
        readyToThrow = false;

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
