using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float CheckFrequency = 0.1f;
    private GameObject Player;

    private Transform CurrentPlayerLocation;

    private EnemyMovement enemyMovement;
    
    void Start()
    {
        Invoke("StartWithDelay", 0.1f);
    }

    public void HandleChase()
    {
        Chase(CurrentPlayerLocation);   
    }

    private IEnumerator CheckPlayerPosition()
    {
        while (true)
        {
            CurrentPlayerLocation = Player.transform;
            yield return new WaitForSeconds(CheckFrequency);
        }
    }

    private void Chase(Transform transform)
    {
        enemyMovement.MoveToLocation(transform.position, 25f);
    }

    private void StartWithDelay()
    {
        enemyMovement = GetComponent<EnemyMovement>();

        if (enemyMovement != null)
        {
            Debug.Log("EnemyChase Script cannot locate EnemyMovement Script.");
        }

        Player = GameObject.FindWithTag("Player");

        if (Player == null)
        {
            Debug.Log("EnemyChase Script cannot locate the Player.");
        }

        StartCoroutine(CheckPlayerPosition());
    }

}
