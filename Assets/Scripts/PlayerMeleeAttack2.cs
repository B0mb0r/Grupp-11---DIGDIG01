using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack2 : MonoBehaviour
{
    [Header("HurtBoxes")]
    public GameObject attackHurtBoxFoward;
    public GameObject attackHurtBoxUp;
    public GameObject attackHurtBoxDown;
    [Header("Transforms")]
    public Transform attackDirection;
    public Transform attackDirectionUp;
    public Transform attackDirectionDown;
    [Header("attackTimer")]
    public float attackTimer;
    public float attackTimerMaxValue;
    public bool canAttack;
    private Rigidbody2D rbodyPlayer;
    private bool lookingUp;
    private bool lookingDown;
    
    void Attacking()
    {
        if (Input.GetKeyDown(KeyCode.J) && lookingUp == false && canAttack == true)
        {
            print("attacking");
            Instantiate(attackHurtBoxFoward, attackDirection);
            attackTimer = attackTimerMaxValue;
        }
        if(Input.GetKeyDown(KeyCode.D) && lookingUp == true && lookingDown == false && canAttack == true)
        {
            print("attacking up");
            Instantiate(attackHurtBoxUp, attackDirectionUp);
            attackTimer = attackTimerMaxValue;
        }
    }
    void CanAttackUp()
    {
        if (Input.GetKey(KeyCode.W))
        {
            lookingUp = true;
        }
        else
        {
            lookingUp = false;
        }
    }

    void CanAttackDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            lookingDown = true;
        }
        else
        {
            lookingDown = false;
        }
    }
    void AttackingCooldown()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            canAttack = true;
            attackTimer = 0;
        }
        else
        {
            canAttack = false;
        }
    }
}
