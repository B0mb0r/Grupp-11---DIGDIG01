﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackUp : MonoBehaviour
{
    public int damage;
    public int lifeSteal = 1;
    public float startTimeBtwAttack;
    private float timeBtwAttack;
    public Animator animator;

    public Transform attackPosition;
    public float rangeX;
    public float rangeY;
    public LayerMask whatIsEnemies;

    public PlayerRangedAttack ranged;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Input.GetAxis("Vertical") > 0)
        {
            if (timeBtwAttack <= 0)
            {
                timeBtwAttack = startTimeBtwAttack;
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosition.position, new Vector2(rangeX, rangeY), 0, whatIsEnemies);
                animator.SetBool("isAttackingVertical", true);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
<<<<<<< HEAD
                    EnemyHealthSystem ehs;
                    ehs = enemiesToDamage[i].GetComponent<EnemyHealthSystem>();
                    if (ehs)
                    {
                        ehs.TakeDamage(damage);
                    }
                    BossHealth boss;
                    boss = enemiesToDamage[i].GetComponent<BossHealth>();
                    if (boss)
                    {
                        boss.TakeDamage(damage);
                    }
                    WalkingEnemy walking;
                    walking = enemiesToDamage[i].GetComponent<WalkingEnemy>();
                    if (walking)
                    {
                        walking.TakeDamage(damage);
                    }

=======
                    enemiesToDamage[i].GetComponent<EnemyHealthSystem>().TakeDamage(damage);
                    ranged.refillHits++;
>>>>>>> Hugo
                    GetComponent<Health>().LifeSteal(lifeSteal);
                }
                Debug.Log("AttackedUp");
            }
        }
        else
        {
            animator.SetBool("isAttackingVertical", false);
            timeBtwAttack -= Time.deltaTime;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPosition.position, new Vector3(rangeX, rangeY, 1));
    }
}
