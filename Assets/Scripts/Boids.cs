using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{

    public int boidAmount;

    public float boidSpeed;

    public float boidRange;

    public GameObject boidPrefab;

    public List<Boid> boids = new List<Boid>();

    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < boidAmount; i++)
        {
            Boid boid = new Boid(Instantiate(boidPrefab), boidRange, boidSpeed);
            boid.boidPrefab.AddComponent<Rigidbody>();
            boid.boidPrefab.GetComponent<Rigidbody>().useGravity = false;
            boids.Add(boid);   
            if(i == boidAmount-1)
            {
                done = true;
            }
        }
        if(done)
        {
            for(int i = 0; i < boids.Count; i++ )
            {
                boids[i].UpdateBoids(boids);
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
                //boids[i].MoveForward();
                if (boids[i].boids != null)
                {
                    boids[i].GetNearbyBoids();
                }
                if (boids[i].friends!= null)
                {
                }
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

public class Boid : MonoBehaviour
{
    public GameObject boidPrefab;

    public List<Boid> friends;

    public List<Boid> boids;

    public float boidSpeed;

    private float boidRange;

    public Boid(GameObject boidPrefab, float boidRange, float boidSpeed)
    {
        this.boidPrefab = boidPrefab;
        this.boidRange = boidRange;

        friends = new List<Boid>();
        this.boidSpeed = boidSpeed;
    }

    private void Update()
    {
        Vector3 AvoidDir = CalculateSeparationDirection();
        boidPrefab.GetComponent<Rigidbody>().velocity = AvoidDir.normalized * boidSpeed;
    }


    public void GetNearbyBoids()
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
        friends = nearby;
    }

    public void MoveForward()
    {
        boidPrefab.GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0));
    }
    public void UpdateBoids(List<Boid> boids)
    {
        this.boids = boids;
    }

   

    public Vector3 CalculateSeparationDirection()
    {
        Vector3 separation = Vector3.zero;

        foreach (Boid friend in friends)
        {
            if (friend != transform)
            {
                Vector3 offset = friend.boidPrefab.transform.position - boidPrefab.transform.position;
                float distance = offset.magnitude;

                // Check if the friend is too close
                if (distance < boidRange)
                {
                    // Calculate a separation force based on the distance
                    float separationFactor = 1.0f - (distance / boidRange);
                    separation += -offset.normalized * separationFactor;
                }
            }
        }

        return separation;
    }



}