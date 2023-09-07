using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{

    public int boidAmount;

    public float boidSpeed;

    public float boidRange;

    public GameObject boidPrefab;

    public List<GameObject> boids;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < boidAmount; i++)
        {
            GameObject boid = Instantiate(boidPrefab);
            boid.AddComponent<Rigidbody>();
            boids.Add(boid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(boids != null)
        {
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1));
            }
        }

    }

    void Separtion(GameObject boid)
    {
        Physics.CheckSphere(boid.transform.position, boidRange);
        for(int i = 0; i < boids.Count;i++)
        {
            if (Vector3.Distance(boid.transform.position, boids[i].transform.position) < boidRange)
            {

            }
        }
    }

    void Alignment()
    {

    }

    void Cohesion()
    {

    }
}

public class Boid
{
    public GameObject boidPrefab;
    public Boid(GameObject boidPrefab)
    {
        this.boidPrefab = boidPrefab;
    }

}