using System;
using UnityEngine;

public class ThrowableAddons : MonoBehaviour
{
    public int damage;
    private Rigidbody rb;
    private bool targetHit;
    public GameObject plant;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            GameObject plant = Instantiate(this.plant);
            plant.transform.position = this.gameObject.transform.position;
            plant.transform.parent = collision.gameObject.transform;
            Destroy(this.gameObject);

        }
    }

    /*private GameObject Instantiate(GameObject plant, Vector3 position)
    {
        throw new NotImplementedException();
    }*/
}
