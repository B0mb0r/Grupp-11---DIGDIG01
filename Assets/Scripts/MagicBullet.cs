using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int MBDamage = 1;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealthSystem enemy = hitInfo.GetComponent<EnemyHealthSystem>();
        if(enemy != null)
        {
            enemy.TakeDamage(MBDamage);
        }
        if (hitInfo.tag == "Enemy" || hitInfo.tag == "Ground")
        {
            Debug.Log("TJENA");
            Destroy(gameObject);
        }
        
    }
}
