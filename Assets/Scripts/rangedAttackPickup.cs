using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAttackPickup : MonoBehaviour
{

    public GameObject Player;
    public GameObject FirePoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate<GameObject>(FirePoint);

            Destroy(gameObject);
        }
    }

}
