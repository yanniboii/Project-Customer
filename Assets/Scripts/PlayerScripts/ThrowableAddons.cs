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
            ThrowableSeeds thisPlant = collision.gameObject.GetComponent<ThrowableSeeds>();
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
            if (thisPlant.isFatM)
            {
                plant = Instantiate(plants[2]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isMTall)
            {
                float random = UnityEngine.Random.Range(3, 4);
                plant = Instantiate(plants[(int)random]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }
            if (thisPlant.isMush)
            {
                float random = UnityEngine.Random.Range(5, 6);
                plant = Instantiate(plants[(int)random]);
                plant.transform.position = this.gameObject.transform.position;
                plant.transform.parent = collision.gameObject.transform;
            }

            Destroy(this.gameObject);

        }
    }

}
