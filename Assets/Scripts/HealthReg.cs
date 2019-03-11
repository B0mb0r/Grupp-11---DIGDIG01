using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReg : MonoBehaviour
{
    public int maxHealth;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TestPlayerHealth.health++;
            Destroy(gameObject);
            print("health:" + TestPlayerHealth.health );
        }
     
    }
}
