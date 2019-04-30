using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public GameObject objectDestroy;
    // the amount of health the enamy starts with.
    public int startingHealth = 1;
    // the current health the enemy have.
    public int currentHealth;
    // if the enemy is dead.
    public bool isDead;
    
    // Start is called before the first frame update
    void Awake()
    {
        isDead = false;
        // Setting the current health when enemy spawn
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            isDead = true;
            TrueDeath();
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {

        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            isDead = true;
            TrueDeath();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("damage TAKEN");
    }

    public void TakeDamageRanged(int MBdamage)
    {
        currentHealth -= MBdamage;
        Debug.Log("damage TAKEN from Ranged");
    }

    void TrueDeath()
    {
        
        if (isDead == true)
        {
            Destroy(objectDestroy);
        }
    }

}
