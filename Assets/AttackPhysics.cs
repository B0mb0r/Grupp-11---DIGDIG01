using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPhysics : MonoBehaviour
{

    public float activeTime;

    private Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        activeTime -= Time.deltaTime;

        if (activeTime <= 0)
            Destroy(gameObject);
    }
}
