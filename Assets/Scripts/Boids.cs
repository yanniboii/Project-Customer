using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{

    public int boidAmount;

    public float boidSpeed;

    public float boidRange;

    public GameObject boidPrefab;

    public List<Boid> boids;

    private
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < boidAmount; i++)
        {
            Boid boid = new Boid(Instantiate(boidPrefab), boids, boidRange);
            boid.boidPrefab.AddComponent<Rigidbody>();
            boids.Add(boid);
            if(i == boidAmount)
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(boids != null)
        {
            for (int i = 0; i < boids.Count; i++)
            {
                boids[i].boidPrefab.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1));
            }
        }

    }



    void Separtion(GameObject boid)
    {
        Physics.CheckSphere(boid.transform.position, boidRange);
        for(int i = 0; i < boids.Count;i++)
        {
            if (Vector3.Distance(boid.transform.position, boids[i].boidPrefab.transform.position) < boidRange)
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

    public List<Boid> friends;

    private List<Boid> boids;

    private float boidRange;

    public Boid(GameObject boidPrefab, List<Boid> boids, float boidRange)
    {
        this.boidPrefab = boidPrefab;
        this.boids = boids;
        this.boidRange = boidRange;

        friends = new List<Boid>();
    }

    void GetNearbyBoids()
    {
        List<Boid> nearby = new List<Boid>();

        for (int i = 0; i < boids.Count; i++)
        {
            Boid test = boids[i];
            if (test == this)
            {
                return;
            }
            if (Vector3.Distance(test.boidPrefab.transform.position, boids[i].boidPrefab.transform.position) < boidRange)
            {
                nearby.Add(test);
            }
        }

    }

}