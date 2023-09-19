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
        if(fernAmount >= 2 && tallMAmount >= 2 && !hasDeer)
        {
            hasDeer = true; 
            deerBadge.SetAlpha(255f);
            Instantiate(deerGameObject, deerTransform);
        }
        //Bird Conditions
        if(mushAmount >= 5 && fatMAmount >=5 && !hasBird)
        {
            hasBird = true;
            crowBadge.SetAlpha(255f);
            boids.boidAmount = 20;
            boids.spawnRange= 5;
            boids.SpawnBoids();
        }

        //fox Conditions
        if (fernAmount >= 2 && tallMAmount >= 2 && !hasFox)
        {
            hasFox = true;
            foxBadge.SetAlpha(255f);
            Instantiate(foxGameObject, foxTransform);
        }

        //racoon Conditions
        if (fernAmount >= 2 && tallMAmount >= 2 && !hasRacoon)
        {
            hasRacoon = true;
            racoonBadge.SetAlpha(255f);
            Instantiate(racoonGameObject, racoonTransform);
        }
    }
}
