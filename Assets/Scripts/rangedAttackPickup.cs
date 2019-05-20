using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAttackPickup : MonoBehaviour
{

    public GameObject Player;
    public PlayerRangedAttack ranged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ranged.isDisabled = false;

            Destroy(gameObject);
        }
    }

}
