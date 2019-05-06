using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    public float jumpSpeed = 12f;
    private bool isJumping;
    public float jumpTimeCounter;
    public float jumpTime = 0.6f;

    public float dashSpeed = 25f;
    public float dashCooldown = 1f;
    public float dashCooldownRemaining;
    public float dashtime = 0.1f;
    public float startdashtime = 0.1f;
    public float dashCounter = 1;

    private int lookDirection;

    public GroundChecker groundCheck;


    public float knockbackx;
    private float knockbacky;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public float defaultKnockback;
    public float stunExtension;
    public bool invincible = false;

    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;


    private Rigidbody2D rbody;

    public void A()
    {
        if (!invincible)
        {
            
            invincible = true;
            Invoke("ResetInvulnerability", 2);
        }
    }
    void ResetInvulnerability()
    {
        invincible = false;
    }
    public void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        dashtime = startdashtime;
        knockbacky = defaultKnockback;
    }

    void Update()
    {
        //walk and knockback
        if (knockbackCount <= 0)
        {
            rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);

            knockbacky = defaultKnockback;
        }
        else
        {
            if (knockFromRight)
                rbody.velocity = new Vector2(-knockbackx, knockbacky);
            if (!knockFromRight)
                rbody.velocity = new Vector2(knockbackx, knockbacky);
            knockbackCount -= Time.deltaTime;
            knockbacky -= 10 * Time.deltaTime;



        }

        //Jump
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded == true)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
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

        //Dash
        if (Input.GetAxis("Horizontal") > 0)
        {
            lookDirection = -1;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            lookDirection = 1;
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetButton("Fire3") && dashtime > 0 && dashCooldownRemaining <= 0 && dashCounter > 0 && knockbackCount <= 0)
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
            isJumping = false;
            rbody.velocity = new Vector2(rbody.velocity.x, 0);
        }
        dashCooldownRemaining = dashCooldownRemaining - (1 * Time.deltaTime);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        dashCounter = 1 * Time.deltaTime;
    }
}
