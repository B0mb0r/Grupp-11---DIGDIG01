using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    public float jumpSpeed = 12f;

    public float dashSpeed;
    public float dashCooldown = 3;
    public float dashCooldownRemaining;
    public float dashtime = 0.1f;
    public float startdashtime = 0.1f;

    private int lookDirection;

    public float dashCounter = 1;

    public GroundChecker groundCheck;

    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        //Våran variabel kopplas till rätt rigidbody
        rbody = GetComponent<Rigidbody2D>();
        dashtime = startdashtime;
    }

    // Update is called once per frame
    void Update()
    {
        //När en av horizontala rörelse knapparna trycks in så går Player i den riktningen med Playerns moveSpeed
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.A))
        {
            lookDirection = 1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lookDirection = 2;
        }
        //Om hopp knappen trycks in så händer något
        if (Input.GetButtonDown("Jump"))
        {
            if (groundCheck.isGrounded == true)
            {
                rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && dashtime > 0 && dashCooldownRemaining <= 0 && dashCounter > 0)
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
}
