﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public CharacterController controller2D;






    public float jumpSpeed = 12f;
    private bool isJumping;
    public float jumpTimeCounter;
    public float jumpTime = 0.35f;
    private bool isFalling;
    private bool P_FacingRight = true;

    public float dashSpeed;
    public float dashCooldown = 3;
    public float dashCooldownRemaining;
    public float dashtime = 0.1f;
    public float startdashtime = 0.1f;
    public float dashCounter = 1;

    private int lookDirection;

    public GroundChecker groundCheck;

    private Rigidbody2D rbody;



    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        dashtime = startdashtime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //Walk
    void Update()
    {
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(rbody.velocity.x) / moveSpeed);


        //Jump
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButton("Jump") && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;

            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;


        }

        if (isJumping == false && groundCheck.isGrounded == false)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
    

        if (isJumping == false && groundCheck.isGrounded == true)
        {
            animator.SetBool("isFalling", false);
        }

//Dash

        if (Input.GetAxis("Horizontal") > 0)
        {
            lookDirection = -1;
            if (P_FacingRight == false)
            {
                Flip();
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            lookDirection = 1;
            if (P_FacingRight == true)
            {
                Flip();
            }
        }



        if (Input.GetButton("Fire3") && dashtime > 0 && dashCooldownRemaining <= 0 && dashCounter > 0)
        {
            if (lookDirection == 1)
            {
                rbody.velocity = new Vector2(-dashSpeed, rbody.velocity.y);
dashtime -= Time.deltaTime;
                if (dashtime <= 0)
                {
                    dashtime = startdashtime;
                    dashCooldownRemaining = dashCooldown;
                    dashCounter = dashCounter - 1;
                }
            }
            else
            {
                rbody.velocity = new Vector2(dashSpeed, rbody.velocity.y);
dashtime -= Time.deltaTime;
                if (dashtime <= 0)
                {
                    dashtime = startdashtime;
                    dashCooldownRemaining = dashCooldown;
                    dashCounter = dashCounter - 1;
                }
            }
        }
        dashCooldownRemaining = dashCooldownRemaining - (1 * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
{
    dashCounter = 1 * Time.deltaTime;
}
    void Flip()
    {
        P_FacingRight = !P_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}
