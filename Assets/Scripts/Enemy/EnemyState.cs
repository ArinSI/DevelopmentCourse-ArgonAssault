using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    // Reference to the other scripts
    private EnemyPlayerIdentifier playerIdentifier;
    private EnemyHealth enemyHealth;
    private EnemyPatrol enemyPatrol;
    private EnemyChase enemyChase;
    private EnemyCombat enemyCombat;

    // Enum for the states
    public enum State
    {
        Patrol,
        Chase,
        Combat,
        Death
    }

    // Current state of the enemy
    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartWithDelay", 0.2f);
    }

    // OnStateEnter Function that will be executed once upon entering a new state
    private void OnStateEnter(State state)
    {
        switch (state)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Combat:
                Combat();
                break;
            case State.Death:
                Death();
                break;
        }
    }

    // OnStateUpdate Function that will be executed once upon trying to change into the same state
    private void OnStateUpdate(State state)
    {
        switch (state)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                Chase();
                break;
            case State.Combat:
                Combat();
                break;
            case State.Death:
                // Death state might not require updates, as it's typically final
                break;
        }
    }

    // OnStateExit Function that will be executed once upon exiting a state
    private void OnStateExit(State state)
    {
        switch (state)
        {
            case State.Patrol:
                
                break;
            case State.Chase:
                
                break;
            case State.Combat:
                
                break;
            case State.Death:
                // Death state does not need to exit, it's the final state
                break;
        }
    }

    // Function to handle state transitions
    private void TransitionToState(State newState)
    {
        // Call OnStateExit for the current state
        OnStateExit(currentState);

        // Update the current state to the new state
        currentState = newState;

        // Call OnStateEnter for the new state
        OnStateEnter(newState);
    }
    // Logic for identifying the current state based on conditions
    public void IdentifyState()
    {
        if (enemyHealth != null && enemyHealth.isDead)
        {
            TransitionToState(State.Death);
            return;
        }

        if (playerIdentifier != null)
        {
            if (!playerIdentifier.isSightRange)
            {
                TransitionToState(State.Patrol);
                return;
            }

            if (playerIdentifier.isSightRange && !playerIdentifier.isCombatRange)
            {
                TransitionToState(State.Chase);
            }

            if (playerIdentifier.isCombatRange)
            {
                TransitionToState(State.Combat);
            }
        }
    }

    // Placeholder methods for entering, updating, and exiting each state
    private void Patrol()
    {
        Debug.Log("Entering Patrol State.");
        enemyPatrol.HandlePatrol();
    }
    private void Chase()
    {
        Debug.Log("Entering Chase State.");
        enemyChase.HandleChase();
    }

    private void Combat()
    {
        Debug.Log("Entering Combat State.");
        // Add logic for entering Combat state (e.g., prepare to attack)
        enemyCombat.HandleCombat();
    }

    private void Death()
    {
        Debug.Log("Entering Death State.");
        // Add logic for entering Death state (e.g., play death animation, destroy object)
    }

    private void StartWithDelay()
    {
        playerIdentifier = GetComponentInChildren<EnemyPlayerIdentifier>();

        if (playerIdentifier == null)
        {
            Debug.Log("Player Identifier cannot be located by the EnemyState.");
        }

        enemyHealth = GetComponent<EnemyHealth>();

        if (enemyHealth == null)
        {
            Debug.Log("EnemyHealth reference cannot be located by the EnemyState.");
        }

        enemyPatrol = GetComponent<EnemyPatrol>();

        if (enemyPatrol == null)
        {
            Debug.Log("EnemyPatrol reference cannot be located by the EnemyState.");
        }

        enemyChase = GetComponent<EnemyChase>();

        if (enemyChase == null)
        {
            Debug.Log("EnemyChase reference cannot be located by the EnemyState.");
        }

        enemyCombat = GetComponent<EnemyCombat>();

        if (enemyCombat == null)
        {
            Debug.Log("EnemyCombat reference cannot be located by the EnemyState.");
        }

        // Initialize the enemy's state to Patrol
        TransitionToState(State.Patrol);
    }
}
