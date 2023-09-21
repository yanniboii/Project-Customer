using System;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableAddons : MonoBehaviour
{
    public int damage;
    private Rigidbody rb;
    private bool targetHit;
    public List<GameObject> plants= new List<GameObject>();
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //collides with the first target
        if (targetHit)
            return;
        else
            targetHit = true;


        if (collision.gameObject.GetComponent<Terrain>() != null)
        {
            GameObject plant;
            ThrowableSeeds thisPlant = this.gameObject.GetComponentInParent<ThrowableSeeds>();
            if (thisPlant.isGrass)
            {
                plant = Instantiate(plants[0]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isFern)
            {
                plant = Instantiate(plants[1]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isMush)
            {
                plant = Instantiate(plants[2]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isBerry)
            {
                plant = Instantiate(plants[3]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isBramble)
            {
                plant = Instantiate(plants[4]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isHolly)
            {
                plant = Instantiate(plants[5]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isLavender)
            {
                plant = Instantiate(plants[6]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isOak)
            {
                plant = Instantiate(plants[7]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isAsh)
            {
                plant = Instantiate(plants[8]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isHazel)
            {
                plant = Instantiate(plants[9]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }


            Destroy(this.gameObject);

        }
    }

}
