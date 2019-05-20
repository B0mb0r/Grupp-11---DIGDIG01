using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public GroundChecker groundCheck;

    public float jumpCooldown = 1f;
    private float jumpCdCounter;
<<<<<<< HEAD
    public float verticalJumpForce = 10f;
    public float horizontalJumpForce = 5f;
    public Transform target;
=======
    public int jumps;
    public float minVerticalJumpForce = 5f;
    public float maxVerticalJumpForce = 15f;
    public float minHorizontalJumpForce = 3f;
    public float maxHorizontalJumpForce = 7f;
    public float gravityModifier = 1f;
>>>>>>> Hugo

    private bool P_FacingRight = true;

    private Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        jumpCdCounter += Time.deltaTime;

        Physics.gravity = new Vector3(0, 1.0F, 0);

        if (groundCheck.isGrounded == true && jumpCdCounter > jumpCooldown && P_FacingRight == true)
        {
            rbody.velocity = new Vector2(Random.Range(minHorizontalJumpForce, maxHorizontalJumpForce), Random.Range(minVerticalJumpForce,maxVerticalJumpForce));
        }
        if (groundCheck.isGrounded == true && jumpCdCounter > jumpCooldown && P_FacingRight == false)
        {
            rbody.velocity = new Vector2(Random.Range(-minHorizontalJumpForce, -maxHorizontalJumpForce), Random.Range(minVerticalJumpForce, maxVerticalJumpForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumpCdCounter = 0;
        jumps++;

        if(jumps == 2)
        {
            P_FacingRight = !P_FacingRight;
            transform.Rotate(0, 180, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(jumps == 2)
        {
            jumps = 0;
        }
    }
}
