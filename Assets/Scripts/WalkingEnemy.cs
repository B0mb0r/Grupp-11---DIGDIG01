
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool movingRight = true;
    public Transform groundDetection;
    public LayerMask whatIsGround;
    public float dazedTime;
    public float startDazedtime = 0.2f;
    public GameObject objectDestroy;
    public int startingHealth = 1;
    public int currentHealth;
    public bool isDead;

    void Awake()
    {
        isDead = false;
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("damage TAKEN");
        dazedTime = startDazedtime;
    }

    public void Update()
    {
        if (dazedTime <= 0)
        {
            speed = 3.5f;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (currentHealth <= 0)
        {
            isDead = true;
            TrueDeath();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, whatIsGround);
        if (groundInfo.collider == null)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
    
    void TrueDeath()
    {

        if (isDead == true)
        {
            Destroy(objectDestroy);
        }
    }

}
