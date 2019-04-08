﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackUp : MonoBehaviour
{
    public int damage;
    public int lifeSteal = 1;
    public float startTimeBtwAttack;
    private float timeBtwAttack;

    public Transform attackPosition;
    public float rangeX;
    public float rangeY;
    public LayerMask whatIsEnemies;
    public PlayerMovement PlayerMovement;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.W) && PlayerMovement.knockbackCount <= 0)
        {
            if (timeBtwAttack <= 0)
            {
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosition.position, new Vector2(rangeX, rangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealthSystem>().TakeDamage(damage);
                    GetComponent<Health>().LifeSteal(lifeSteal);
                }
                Debug.Log("AttackedUp");
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPosition.position, new Vector3(rangeX, rangeY, 1));
    }
}
