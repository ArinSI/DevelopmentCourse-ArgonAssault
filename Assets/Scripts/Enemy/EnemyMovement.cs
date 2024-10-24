using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Patrol movement speed
    public bool isMoving = false;

    //Script References
    private EnemyState enemyState;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartWithDelay", 0.1f);
    }

    public void MoveToLocation(Vector3 targetLocation, float distance)
    {
        // Move towards the given location using MoveTowards
        StartCoroutine(MoveToTarget(targetLocation, distance));
    }

    private IEnumerator MoveToTarget(Vector3 targetLocation, float distance)
    {
        // Continue moving towards the target until the enemy reaches the point
        while (Vector3.Distance(transform.position, targetLocation) > distance)
        {
            isMoving = true;

            // Calculate step size based on speed and frame time
            float step = speed * Time.deltaTime;

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);

            // Yield execution until the next frame
            yield return null;
        }

        isMoving = false;
        Debug.Log("Enemy reached the patrol point.");

        enemyState.IdentifyState();
        
    }

    private void StartWithDelay()
    {
        enemyState = GetComponent<EnemyState>();

        if (enemyState == null)
        {
            Debug.Log("EnemyState cannot be located by EnemyMovement.");
        }
    }
}
