using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    // the amount of health the enamy starts with.
    public int startingHealth = 1;
    // the current health the enemy have.
    public int currentHealth;
    // if the enemy is dead.
    bool isDead; 
    
    // Start is called before the first frame update
    void Awake()
    {
        // Setting the current health when enemy spawn
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        // if enemy is dead.
        if (isDead)
            // exit the damage function.
            return;
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
    }

}
