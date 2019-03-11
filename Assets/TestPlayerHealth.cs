using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerHealth : MonoBehaviour
{
<<<<<<< HEAD:Assets/Scripts/TestPlayerHealth.cs
    public static int health;
=======
    public float health;
    public float moveSpeed;

    private Rigidbody2D rbody;
>>>>>>> 36ab5491a487af3b5c7a16ab698bf8d20882806b:Assets/TestPlayerHealth.cs
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rbody.velocity.y);
    }
}
