using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;

    public float jumpSpeed = 12f;

    public float dashSpeed;
    private int lookDirection;

    public GroundChecker groundCheck;

    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        //Våran variabel kopplas till rätt rigidbody
        rbody = GetComponent<Rigidbody2D>();
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
            //Om vi står på marken händer något
            if (groundCheck.isGrounded == true)
            {
                //Playern hoppar
                rbody.velocity = new Vector2(rbody.velocity.x, jumpSpeed);
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (lookDirection == 1)
            {
                rbody.velocity = new Vector2(-dashSpeed, rbody.velocity.y);
            }
            else
            {
                rbody.velocity = new Vector2(dashSpeed, rbody.velocity.y);
            }
        }
    }
}
