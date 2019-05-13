﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackHorizontal : MonoBehaviour
{
    public int damage;
    public int lifeSteal = 1;
    public float startTimeBtwAttack;
    private float timeBtwAttack;

    public Transform attackPosition;
    public float rangeX;
    public float rangeY;
    public LayerMask whatIsEnemies;
    public bool WOrSIsPressed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            WOrSIsPressed = true;
        }
        if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Vertical") == 0)
        {
            WOrSIsPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))

        if (Input.GetButton("Fire1"))

        {
            if (WOrSIsPressed == false)
                if (timeBtwAttack <= 0)
                {
                    timeBtwAttack = startTimeBtwAttack;
                    Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosition.position, new Vector2(rangeX, rangeY), 0, whatIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {

                        enemiesToDamage[i].GetComponent<EnemyHealthSystem>().TakeDamage(damage);

                    }
                 
                    Debug.Log("Attacked");
                }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPosition.position, new Vector3(rangeX, rangeY, 1));
    }
}
