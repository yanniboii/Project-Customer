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
            Vector3 pos = new Vector3(Random.Range(0, 50f), Random.Range(0, 50f), Random.Range(0, 50f));
            GameObject boid = Instantiate(boidPrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
