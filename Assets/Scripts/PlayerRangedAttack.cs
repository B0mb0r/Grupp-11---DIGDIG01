using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject MagicBullet;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(MagicBullet, FirePoint.position, FirePoint.rotation);
    }
}
