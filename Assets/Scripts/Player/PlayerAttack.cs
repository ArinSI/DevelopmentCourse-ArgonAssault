using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Set Up Variables
    public Transform MuzzleTransform;
    public GameObject ProjectilePrefab;
    public float AttackCooldown;
    
    // Set Up Bools
    private bool isCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Attack()
    {
        if (!isCooldown)
        {
            Instantiate(ProjectilePrefab, MuzzleTransform.position, MuzzleTransform.rotation);
            isCooldown = true;
            Invoke("ResetAttack", AttackCooldown);
        }
    }

    private void ResetAttack()
    {
        isCooldown = false;
    }
}
