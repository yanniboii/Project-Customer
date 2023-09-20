using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public LayerMask whatIsGround;

    public Vector3 nextPoint;
    bool nextPointSet;
    public float nextPointRange;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Patroling();
    }

    private void Patroling()
    {
        if (!nextPointSet)
        {
            SearchNextPoint();
        }

        if (nextPointSet)
        {
            agent.SetDestination(nextPoint);
        }
        Vector3 distanceToNextPoint = transform.position - nextPoint;

        if (distanceToNextPoint.magnitude < 1f)
        {
            nextPointSet = false;
        }
    }
    private void SearchNextPoint()
    {
        float randomZ = Random.Range(-nextPointRange, nextPointRange);
        float randomX = Random.Range(-nextPointRange, nextPointRange);

        nextPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(nextPoint, -transform.up, 2f, whatIsGround))
        {
            nextPointSet = true;
        }
    }
}
