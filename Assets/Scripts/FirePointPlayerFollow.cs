using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointPlayerFollow : MonoBehaviour
{

    public float FirePointOffset = .5f;
    public GameObject Player;
    private bool P_FacingRight = true;

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
        transform.position = new Vector3(Player.transform.position.x + FirePointOffset, Player.transform.position.y, Player.transform.position.z);
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (P_FacingRight == false)
            {
                Flip();
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (P_FacingRight == true)
            {
                Flip();
            }
        }
        void Flip()
        {
            P_FacingRight = !P_FacingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }
}
