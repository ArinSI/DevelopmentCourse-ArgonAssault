using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Declare Variables
    public float PatrolRadius = 10f;

    // Declare private Variables
    private Vector3 spawnLocation;
    private Vector3 newPoint;

    // Declare Script References
    private EnemyMovement enemyMovement;

    void Start()
    {
        Invoke("StartWithDelay", 0.1f);
    }

    public void HandlePatrol()
    {
        // Identify a new point inside the patrol radius, based on the initial spawn position
        IdentifyNewPoint(PatrolRadius, spawnLocation);

        // Send the identified point to the enemyMovement script to make our enemy move towards that location
        enemyMovement.MoveToLocation(newPoint, 0.25f);
    }

    private void IdentifyNewPoint(float patrolRadius, Vector3 origin)
    {
        // Generate a random point inside a circle (2D) then add it to the origin for 3D patrol
        Vector2 randomPoint = Random.insideUnitCircle * patrolRadius;
        newPoint = new Vector3(origin.x + randomPoint.x, origin.y, origin.z + randomPoint.y);

        Debug.Log("New patrol point identified: " + newPoint);
    }

    private void StartWithDelay()
    {
        spawnLocation = gameObject.transform.position; // Store the initial spawn position

        if (enemyMovement == null)
        {
            Debug.Log("SpawnLocation Cannot be Located.");
        }
        enemyMovement = GetComponent<EnemyMovement>();

        if (enemyMovement == null)
        {
            Debug.LogError("EnemyMovement script not found!");
        }
    }
}
