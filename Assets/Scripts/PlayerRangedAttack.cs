using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject MagicBullet;

    public int maxAmmo = 5;
    public int currentAmmo;

    public bool meleeHit = false;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && currentAmmo > 0)
        {
            Shoot();

            currentAmmo -= 1;
        }
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        if(meleeHit == true)
        {
            Debug.Log("bajs");

            meleeHit = false;
        }
    }

    void Shoot()
    {
        Instantiate(MagicBullet, FirePoint.position, FirePoint.rotation);
    }
}
