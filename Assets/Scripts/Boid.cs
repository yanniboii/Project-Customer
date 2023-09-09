using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Boid : MonoBehaviour
{
    public GameObject boidPrefab;

    public List<Transform> friends;

    public List<Transform> avoids;

    public float boidSpeed;

    public float boidRange;

    public float separationWeight;

    public float alignmentWheight;

    public float cohesionWeight;

    public float avoidWeight;

    public float minSpeed;

    public Boid(GameObject boidPrefab, float boidRange, float boidSpeed)
    {
        this.boidPrefab = boidPrefab;
        this.boidRange = boidRange;

        friends = new List<Transform>();
        this.boidSpeed = boidSpeed;
    }

    private void Update()
    {
        DetectFriends();
        Vector3 flockingDirection = CalcutlateFlockingDirection();
        boidPrefab.GetComponent<Rigidbody>().velocity = flockingDirection * boidSpeed;
    }


    private void DetectFriends()
    {
        friends.Clear(); // Clear the list before detecting new friends

        Collider[] colliders = Physics.OverlapSphere(transform.position, boidRange);

        foreach (Collider collider in colliders)
        {
            if (collider != null && collider.gameObject != gameObject)
            {
                // Check if the detected object has the Boid script attached
                Boid friendBoid = collider.gameObject.GetComponent<Boid>();
                if (friendBoid != null)
                {
                    friends.Add(friendBoid.transform);
                }
                if(collider.tag == "Avoid")
                {
                    avoids.Add(collider.transform);
                }
            }
        }
    }

    public Vector3 CalculateAvoidDirection()
    {
        Vector3 avoiddir = Vector3.zero;

        foreach(Transform avoid in avoids)
        {
            if(avoid != transform)
            {
                Vector3 offset = avoid.transform.position - boidPrefab.transform.position;
                float distance = offset.magnitude;

                // Check if the friend is too close
                if (distance < boidRange)
                {
                    // Calculate a separation force based on the distance
                    float separationFactor = 1.0f - (distance / boidRange);
                    avoiddir += -offset.normalized * separationFactor;
                }
            }
        }
        return avoiddir;
    }

    public Vector3 CalculateSeparationDirection()
    {
        Vector3 separation = Vector3.zero;

        foreach (Transform friend in friends)
        {
            if (friend != transform)
            {
                Vector3 offset = friend.transform.position - boidPrefab.transform.position;
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

    private Vector3 CalculateAlignmentDirection()
    {
        Vector3 alignment = Vector3.zero;

        foreach (Transform friend in friends)
        {
            if (friend != transform)
            {
                Vector3 offset = friend.position - transform.position;
                float distance = offset.magnitude;

                // Check if the friend is within alignment range
                if (distance < boidRange)
                {
                    // Add the friend's velocity to the alignment vector
                    Boid friendBoid = friend.GetComponent<Boid>();
                    if (friendBoid != null)
                    {
                        alignment += friendBoid.boidPrefab.GetComponent<Rigidbody>().velocity;
                    }
                }
            }
        }

        return alignment;
    }
    private Vector3 CalculateCohesionDirection()
    {
        Vector3 centerOfMass = Vector3.zero;
        int count = 0;

        foreach (Transform friend in friends)
        {
            if (friend != transform)
            {
                Vector3 offset = friend.position - transform.position;
                float distance = offset.magnitude;

                // Check if the friend is within cohesion range
                if (distance < boidRange)
                {
                    centerOfMass += friend.position;
                    count++;
                }
            }
        }

        if (count > 0)
        {
            // Calculate the average position of nearby friends
            centerOfMass /= count;

            // Calculate the direction towards the center of mass
            Vector3 cohesionDirection = centerOfMass - transform.position;
            return cohesionDirection;
        }

        // If no nearby friends, return zero vector
        return Vector3.zero;
    }

    Vector3 CalcutlateFlockingDirection()
    {
        Vector3 alignementDirection = CalculateAlignmentDirection();
        Vector3 separationDirection = CalculateSeparationDirection();
        Vector3 cohesionDirection = CalculateCohesionDirection();
        Vector3 avoidDirection = CalculateAvoidDirection();

        avoidDirection.Normalize();
        alignementDirection.Normalize();
        separationDirection.Normalize();
        cohesionDirection.Normalize();

        Vector3 flockingDirection = alignementDirection * alignmentWheight + 
            separationDirection * separationWeight + 
            cohesionDirection * cohesionWeight +
            avoidDirection * avoidWeight;

        flockingDirection.Normalize();

        if(flockingDirection.magnitude < minSpeed)
        {
            flockingDirection = flockingDirection.normalized * minSpeed;
        }

        return flockingDirection;
    }


}
