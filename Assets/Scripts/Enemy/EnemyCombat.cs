using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject EnemyBullet;
    public Transform Muzzle;
    public float AttackCooldown;
    public bool isAttacking = false;
    public float rotationSpeed = 5f; // Speed of the rotation towards the player
    public float Accuracy = 1.0f; // The higher the value, the less accurate the rotation

    // Reference to the player's transform
    private Transform playerTransform;

    // Script References
    private EnemyChase enemyChase;
    private EnemyState enemyState;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartWithDelay", 0.1f);
    }

    public void HandleCombat()
    {
        // Smoothly rotate towards the player with random inaccuracy
        RotateTowardsPlayer();

        if (!isAttacking)
        {
            isAttacking = true;
            Attack();
        }
        else
        {
            Debug.Log("Waiting For Previous Attack Completion.");
        }
    }

    private void RotateTowardsPlayer()
    {
        if (playerTransform != null)
        {
            // Calculate direction to the player
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.y = 0; // Keep the rotation on the horizontal plane (ignore Y axis)

            // Add random inaccuracy by randomizing the direction slightly based on Accuracy
            float inaccuracyX = Random.Range(0, Accuracy); // Random value between 0 and Accuracy
            float inaccuracyZ = Random.Range(0, Accuracy); // Random value between 0 and Accuracy

            // Randomly decide whether to offset positively or negatively
            inaccuracyX *= Random.value > 0.5f ? 1 : -1;
            inaccuracyZ *= Random.value > 0.5f ? 1 : -1;

            // Apply the random inaccuracy to the direction
            directionToPlayer += new Vector3(inaccuracyX, 0, inaccuracyZ);

            // Calculate the target rotation to look at the player (with random inaccuracy)
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate towards the player over time
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Player Transform is null, cannot rotate towards the player.");
        }
    }

    private void Attack()
    {
        // Instantiate the bullet at the muzzle position
        Instantiate(EnemyBullet, Muzzle.transform.position, Muzzle.transform.rotation); // Use muzzle's rotation if you want the bullet to fire forward
        Invoke("ResetAttack", AttackCooldown);
    }

    private void ResetAttack()
    {
        isAttacking = false;
        enemyState.IdentifyState();
    }

    private void StartWithDelay()
    {
        enemyChase = GetComponent<EnemyChase>();

        if (enemyChase == null)
        {
            Debug.Log("EnemyCombat cannot locate the EnemyChase Script.");
        }

        enemyState = GetComponent<EnemyState>();

        if (enemyState == null)
        {
            Debug.Log("EnemyCombat script cannot locate the EnemyState Script.");
        }

        playerTransform = GameObject.FindWithTag("Player").transform;

        if (playerTransform == null)
        {
            Debug.Log("PlayerTransform cannot be located by the EnemyCombat Script.");
        }
    }
}
