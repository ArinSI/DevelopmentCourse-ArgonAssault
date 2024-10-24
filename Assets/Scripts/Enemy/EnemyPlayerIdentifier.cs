using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerIdentifier : MonoBehaviour
{
    // Declare Ranges
    public float SightRange;
    public float CombatRange;

    // Declare how frequently the enemy will look for the player
    public float CheckFrequency;

    // Declare Bools
    public bool isSightRange = false;
    public bool isCombatRange = false;

    // Declare Player Layer
    public LayerMask PlayerLayer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LookForPlayer());
    }

    private IEnumerator LookForPlayer()
    {
        while (true)
        {
            isSightRange = Physics.CheckSphere(gameObject.transform.position, SightRange, PlayerLayer);
            isCombatRange = Physics.CheckSphere(gameObject.transform.position, CombatRange, PlayerLayer);

            yield return new WaitForSeconds(CheckFrequency);
        }
    }

    // Draw gizmos to visualize sight and combat ranges
    private void OnDrawGizmosSelected()
    {
        // Set the color for the sight range
        Gizmos.color = Color.blue;
        // Draw the sight range sphere
        Gizmos.DrawWireSphere(transform.position, SightRange);

        // Set the color for the combat range
        Gizmos.color = Color.red;
        // Draw the combat range sphere
        Gizmos.DrawWireSphere(transform.position, CombatRange);
    }
}
