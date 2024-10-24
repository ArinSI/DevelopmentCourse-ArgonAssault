using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Declare Public Variables
    public int MaxHealth;

    //Declare Private Variables
    private int Health;

    //Declare Bools
    public bool isDead = false;

    void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;

        Debug.Log("Enemy has received" + Health + "Damage.");

        //Enter Taking Damage Effect Here

        if (Health <= 0)
        {
            Health = 0;
            isDead = true;
           //Enter Kill Function Here
        }

    }
}
