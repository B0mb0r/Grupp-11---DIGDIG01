using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debrisBehaviour : MonoBehaviour
{
    public float clearTimer;
    public SpriteRenderer rend;
    public float opacity ;
    public float opacityReduce;
    public Rigidbody2D debris;
    public float initialForce;

    private void Start()
    {
        cameraMovementTest.landShake += 0.5f;
        debris.velocity = (new Vector2 (Random.Range (-initialForce,initialForce ), Random.Range (-initialForce,initialForce)));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        clearTimer -= 1 * Time.deltaTime;

        if (clearTimer <= 0)
        {
            rend.color  = new Color(1, 1, 1, opacity);
            opacity -= opacityReduce  *Time.deltaTime ;
        }
        if (opacity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
