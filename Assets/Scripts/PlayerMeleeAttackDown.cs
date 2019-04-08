using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackDown : MonoBehaviour
{
    public int damage;
    public int lifeSteal = 1;
    public float startTimeBtwAttack;
    private float timeBtwAttack;

    public Transform attackPosition;
    public float rangeX;
    public float rangeY;
    public LayerMask whatIsEnemies;
    public GroundChecker groundCheck;
    public PlayerMovement PlayerMovement;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.S) && groundCheck.isGrounded == false && PlayerMovement.knockbackCount <= 0)
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
                Debug.Log("AttackedDown");
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackPosition.position, new Vector3(rangeX, rangeY, 1));
    }
}
