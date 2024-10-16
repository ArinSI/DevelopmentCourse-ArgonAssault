using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Set Up Public Variables
    public int MaxHealth;

    //Set Up Private Variables
    private int Health;

    // Start is called before the first frame update


    void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;

        //Enter Taking Damage Effect Here

        if (Health <= 0)
        {
            Health = 0;

           //Enter Kill Function Here
        }

    }
}
