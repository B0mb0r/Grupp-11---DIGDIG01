using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    public bool isLeft = true;

    private Rigidbody2D rbody;
    // Use this for initialization
    void Start()
    {
        // hämtar nuvarande position
        rbody = GetComponent<Rigidbody2D>();
        // gör så att fienden inte kan röra på sig
        Move(false);
    }

    // Update is called once per frame
    void Update()
    {
        // om någon trycker på H
        if (Input.GetKeyDown(KeyCode.H))
        {
            // fiemden tillåts röra på sig
            Move(true);
        }
    }
    // gör så att fienden rör på sig
    void Move(bool flip)
    {
        // om flip är sann
        if (flip == true)
        {
            // isLeft får motsatt värdde
            isLeft = !isLeft;
        }
        //om isLeft är sann rör sig fienden åt höger
        if (isLeft == true)
        {// gör så att fienden kan röra sig åt höger
            rbody.velocity = new Vector2(-moveSpeed, rbody.velocity.y);
            // flippar spriten
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {//om isLeft inte är sann rör sig fienden åt vänster
            rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);
            // flippar spriten åt motsatt håll
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {// om fiendens sprite nuddar en osynlig vägg
        if (collision.tag == "InvisibleWall")
        {
            //move funktion kallas med flip=true så att fienden byter håll
            Move(true);
        }
    }
}
