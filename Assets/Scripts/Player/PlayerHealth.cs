using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Declare Public Variables
    public int MaxHealth;

    //Declare Private Variables
    [SerializeField] private int Health;

    public bool isDead = false;

    // Start is called before the first frame update
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
            Time.timeScale = 0;
            
        }

    }
}
