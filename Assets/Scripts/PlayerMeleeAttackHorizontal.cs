using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackHorizontal : MonoBehaviour
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
        if (Input.GetButton("Fire1"))
        {
            if (WOrSIsPressed == false)
                if (timeBtwAttack <= 0)
                {
                    timeBtwAttack = startTimeBtwAttack;
                    Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosition.position, new Vector2(rangeX, rangeY), 0, whatIsEnemies);
                    animator.SetBool("isAttackingHorizontal", true);
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {
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


                        GetComponent<Health>().LifeSteal(lifeSteal);

                    }
                    Debug.Log("Attacked");
                }
        }
        else
        {
            animator.SetBool("isAttackingHorizontal", false);
            timeBtwAttack -= Time.deltaTime;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPosition.position, new Vector3(rangeX, rangeY, 1));
    }
}
