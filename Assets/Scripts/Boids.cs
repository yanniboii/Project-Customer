using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{

    public int boidAmount;

    public GameObject boidPrefab;

    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < boidAmount; i++)
        {
            GameObject boid = Instantiate(boidPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
