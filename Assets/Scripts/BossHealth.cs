using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public bool isDead;
    public GameObject objectDestroy;

    public Slider healthBar;
    // Start is called before the first frame update
    void Awake()
    {
        isDead = false;
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
        if (currentHealth <= 0)
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

    void TrueDeath()
    {

        if (isDead == true)
        {
            Destroy(objectDestroy);
        }
    }
}
