using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
<<<<<<< HEAD
    public Health health;

=======
    
>>>>>>> 7ea3df571e9bce9634e1ccbb6eb93130e7ad540d
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
<<<<<<< HEAD

            health.health = health.health - 1;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
=======
            collision.gameObject.GetComponent<Health>().health -= 1;
            print(collision.gameObject.GetComponent<Health>().health);
>>>>>>> 7ea3df571e9bce9634e1ccbb6eb93130e7ad540d

        }
    }

}
