using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Health health;

    private Transform palyer;
    private Transform ground;
    private Vector2 target; 
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        palyer = GameObject.FindGameObjectWithTag("Player").transform;
               
        target = new Vector2(palyer.position.x, palyer.position.y);


        direction = target - (Vector2)transform.position;
        direction.Normalize();
    }


    
    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().health -= 1;
            print(collision.gameObject.GetComponent<Health>().health);
            DestroyProjectile();
        }

        if (collision.gameObject.tag == "Ground")
        {
            DestroyProjectile();
        }
    }
}
