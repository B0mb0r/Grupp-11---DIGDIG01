using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpStop : MonoBehaviour
{

    public PlayerMovement isJumping;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            PlayerMovement.isJumping = false;
        }
    }
}
