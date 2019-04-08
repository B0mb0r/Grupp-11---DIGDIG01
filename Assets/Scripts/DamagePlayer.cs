using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Health health;
    public int damage;
    public PlayerMovement PlayerMovement;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("PlayerDamaged");

            health.health = health.health - damage;
            //knockback
            var player = collision.collider.GetComponent<PlayerMovement>();
            player.knockbackCount = player.knockbackLength;

            if (collision.collider.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;
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
