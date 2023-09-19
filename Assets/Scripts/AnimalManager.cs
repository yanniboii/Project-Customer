using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public int fernAmount;
    public int fatMAmount;
    public int tallMAmount;
    public int mushAmount;

    bool hasDeer;
    bool hasBird;

    [SerializeField]GameObject deerGameObject;
    [SerializeField]Transform deerTransform;

    [SerializeField] Boids boids;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fernAmount >= 2 && tallMAmount >= 2 && !hasDeer)
        {
            hasDeer = true; 
            Instantiate(deerGameObject, deerTransform);
        }
        if(mushAmount >= 5 && fatMAmount >=5 && !hasBird)
        {
            hasBird = true;
            boids.boidAmount = 20;
            boids.spawnRange= 5;
            boids.SpawnBoids();
        }
    }
}
