using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
<<<<<<< HEAD
    public Health health;
=======
    public Health Health;
>>>>>>> 7a8011e7027bc29b9fb825c233fffdeda3fbbcc5
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
<<<<<<< HEAD
           health.health = health.health - 1;
=======
            Health.health = Health.health - 1;
>>>>>>> 7a8011e7027bc29b9fb825c233fffdeda3fbbcc5
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
