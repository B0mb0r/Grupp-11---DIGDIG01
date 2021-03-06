﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerHealth : MonoBehaviour
{
    public float health;
    public float moveSpeed;

    private Rigidbody2D rbody;
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
