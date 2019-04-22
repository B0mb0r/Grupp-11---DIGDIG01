using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public GroundChecker groundCheck;

    public float jumpCooldown = 1f;
    private float jumpCdCounter;
    public float verticalJumpForce = 10f;
    public float horizontalJumpForce = 5f;

    private bool P_FacingRight = true;

    private Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jumpCdCounter += Time.deltaTime;

        Physics.gravity = new Vector3(0, 1.0F, 0);

        if (groundCheck.isGrounded == true && jumpCdCounter > jumpCooldown && P_FacingRight == true)
        {
            rbody.velocity = new Vector2(horizontalJumpForce, verticalJumpForce);
        }
        if (groundCheck.isGrounded == true && jumpCdCounter > jumpCooldown && P_FacingRight == false)
        {
            rbody.velocity = new Vector2(-horizontalJumpForce, verticalJumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumpCdCounter = 0;

        P_FacingRight = !P_FacingRight;
        transform.Rotate(0, 180, 0);
    }
}
