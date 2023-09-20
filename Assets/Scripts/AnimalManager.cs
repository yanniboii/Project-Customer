using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public List<int> deerConditions = new List<int>();
    public List<int> foxConditions = new List<int>();
    public List<int> racoonConditions = new List<int>();
    public List<int> crowConditions = new List<int>();
    public List<int> plants = new List<int>();



    bool hasDeer;
    bool hasFox;
    bool hasRacoon;
    bool hasBird;

    [SerializeField] BadgeUI deerBadge;
    [SerializeField]GameObject deerGameObject;
    [SerializeField]Transform deerTransform;

    [SerializeField] BadgeUI foxBadge;
    [SerializeField] GameObject foxGameObject;
    [SerializeField] Transform foxTransform;

    [SerializeField] BadgeUI racoonBadge;
    [SerializeField] GameObject racoonGameObject;
    [SerializeField] Transform racoonTransform;

    [SerializeField] BadgeUI crowBadge;
    [SerializeField] Boids boids;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Deer Conditions
        if (plants[0] >= deerConditions[0] && plants[1] >= deerConditions[1] && !hasDeer)
        {
            hasDeer = true; 
            deerBadge.SetAlpha(255f);
            Instantiate(deerGameObject, deerTransform);
        }
        //Bird Conditions
        if(plants[2] >= crowConditions[0] && plants[3] >= crowConditions[1] && !hasBird)
        {
            hasBird = true;
            crowBadge.SetAlpha(255f);
            boids.boidAmount = 200;
            boids.spawnRange= 5;
            boids.SpawnBoids();
        }

        //fox Conditions
        if (plants[4] >= foxConditions[0] && plants[5] >= foxConditions[1] && plants[6] >= foxConditions[2] && !hasFox)
        {
            hasFox = true;
            foxBadge.SetAlpha(255f);
            Instantiate(foxGameObject, foxTransform);
        }

        //racoon Conditions
        if (plants[7] >= racoonConditions[0] && plants[8] >= racoonConditions[1] && plants[9] >= racoonConditions[2] && !hasRacoon)
        {
            hasRacoon = true;
            racoonBadge.SetAlpha(255f);
            Instantiate(racoonGameObject, racoonTransform);
        }
    }
}
