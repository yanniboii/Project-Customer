using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{
    public int boidAmount;

    public float spawnRange;

    public GameObject boidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < boidAmount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
            GameObject boid = Instantiate(boidPrefab, pos, Random.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
