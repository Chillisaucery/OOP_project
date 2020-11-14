using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Other component
    public CharacterController controller;
    public Shooting shooting;

    //Running
    public float moveSpeed = 40f;
    private float horizontal = 0f;
    private float lastHorizontal = 1f;

    public float getHorizontal()
    {
        return horizontal;
    }

    public float getLastHorizontal()
    {
        return lastHorizontal;
    }
    
    //Jumping
    private bool ifJump = false;
    
    public bool getIfJump()
    {
        return ifJump;
    }

    //Dashing
    //public float dashRecharge = 1f;
    //private float rechargeTimer = 0f;
    public float dashMultiplier = 10;
    public float dashDuration = 1.0f;
    private float dashTimer = 0f;
    private float dashSpeed = 1f;
    private bool ableToDash = true;

    public float getDashSpeed()
    {
        return dashSpeed;
    }

    //Attacking
    private bool isAttacking = false;
    public float attackRecharge = 0.2f;
    private float attackTimer = 0f;
    private bool ifAlterBullet = false;

    public bool getIsAttacking()
    {
        return isAttacking;
    }


    //Variables
    

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal == 1 || horizontal == -1)
            lastHorizontal = horizontal;

        if (Input.GetButtonDown("Jump"))
            ifJump = true;

        if (Input.GetButtonDown("Dash") && ableToDash == true)
        {
            dashSpeed = dashMultiplier;
            ableToDash = false;
        }

        //Get button because this let player hold the button
        if (Input.GetButton("Attack") || Input.GetButton("Fire1"))
        {
            isAttacking = true;
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackRecharge)
            {
                shooting.Shoot(ifAlterBullet);
                attackTimer = 0;
            }
        }
        else
        {
            isAttacking = false;
        }

        //Check if the bullet need altering
        if (Input.GetButton("Fire1") && horizontal==0 && dashSpeed==1)
        {
            ifAlterBullet = true;
        }    
        else
        {
            ifAlterBullet = false;
        }

        if (ableToDash == false)
        {
            controller.StopDash();
            dashTimer += Time.deltaTime;
        }

        if (dashTimer >= dashDuration)      //If the player dashed for enough time
        {
            dashSpeed = 1;
            
            if (dashSpeed >= dashDuration *1.5)
            {
                ableToDash = true;
                dashTimer = 0;
            }
        }

    }


    private void FixedUpdate()
    {


        //if (rechargeTimer >= dashRecharge)
        //    rechargeTimer = 0;
        //else rechargeTimer += Time.deltaTime;
            
        controller.Move(horizontal * Time.fixedDeltaTime * moveSpeed, false, ifJump);
        
        if (dashSpeed>1)
            controller.Dash(dashMultiplier * Time.fixedDeltaTime);
        ifJump = false;
        
        
    }
}
