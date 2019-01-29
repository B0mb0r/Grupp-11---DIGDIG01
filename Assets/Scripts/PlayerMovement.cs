using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0, 20f)]
    public float moveSpeed;
    public float jumpHeight;

    public GroundCheck groundCheck;

    private Rigidbody2D rbody;

    // Use this for initialization
    void Start()
    {
        // gör att rbody blir ditt egna Rigidbody
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // unitys inbyggda movement script
        rbody.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rbody.velocity.y);
        // om man trycker på w och groundchek rör en collider så hoppar man
        if (Input.GetKeyDown(KeyCode.W) && groundCheck.touches > 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, jumpHeight);
        }
        // om man trycker på space och groundcjek rör en collider så hoppar man
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.touches > 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, jumpHeight);
        }
    }

}