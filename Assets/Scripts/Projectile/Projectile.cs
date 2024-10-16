using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Set Up Variables
    public int Damage = 1;
    public float DestructionDelay = 1.0f;
    public float BulletSpeedFrequency = 0.05f;
    public float BulletSpeed = 10.0f;
    public float SelfDestructTime = 10.0f;
    private Vector3 direction = Vector3.forward;


    //Set Up Components
    private EnemyHealth enemyHealth;


    //Set Up Bools
    private bool isCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovementRoutine());
        StartCoroutine(SelfDestructTimer());
    }

    private IEnumerator MovementRoutine()
    {
        while(!isCollided)
        {
            transform.Translate(direction * BulletSpeed * Time.deltaTime, Space.Self);
            yield return new WaitForSeconds(BulletSpeedFrequency);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collided with" + other);

            isCollided = true;

            enemyHealth = other.GetComponent<EnemyHealth>();

            enemyHealth.TakeDamage(Damage);

            HandleProjectile();
        }

        if (other.CompareTag("Ground"))
        {
            Debug.Log("Collided With" + other);
            HandleProjectile();
        }

    }

    private void HandleProjectile()
    {
        // Play Effects

        // Destroy Projectile
        Invoke("DestroyProjectile", DestructionDelay);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private IEnumerator SelfDestructTimer()
    {
        yield return new WaitForSeconds(SelfDestructTime);
        DestroyProjectile();
    }

}
