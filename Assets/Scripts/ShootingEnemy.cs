using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectiles;
 

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }


    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(projectiles, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }


}
