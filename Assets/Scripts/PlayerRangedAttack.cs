using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject MagicBullet;

    public int maxAmmo = 5;
    public int currentAmmo;
    public int refillHits;
    public int maxRefillHits = 2;

    public bool isDisabled = true;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && currentAmmo > 0 && isDisabled == false)
        {
            Shoot();

            currentAmmo -= 1;
        }
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        if(maxRefillHits <= refillHits)
        {
            currentAmmo++;

            refillHits = 0;
        }
    }

    void Shoot()
    {
        Instantiate(MagicBullet, FirePoint.position, FirePoint.rotation);
    }
}
