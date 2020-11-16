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

    public float getDashSpeed()
    {
        return dashSpeed;
    }

    //Attacking
    private bool isAttacking = false;
    public float attackDuration = 0.1f;
    private float attackTimer = 0f;

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
        if (horizontal == 1 || horizontal ==-1)
            lastHorizontal = horizontal;

        if (Input.GetButtonDown("Jump"))
            ifJump = true;
        if (Input.GetButtonDown("Dash"))
        {
            dashSpeed = dashMultiplier;
        }
        //Get button (not get button down) because this let player hold the button
        if (Input.GetButton("Attack"))
        {
            isAttacking = true;
            shooting.Shoot();
        }

    }

    private void FixedUpdate()
    {
        if (dashTimer >= dashDuration)      //If the player dashed for enough time
        {
            dashSpeed = 1;
            dashTimer = 0;
            controller.StopDash();
        }
        else
            dashTimer += Time.deltaTime;

        //if (rechargeTimer >= dashRecharge)
        //    rechargeTimer = 0;
        //else rechargeTimer += Time.deltaTime;

        if (attackTimer >= attackDuration)
        {
            isAttacking = false;
            attackTimer = 0;
        }
        else attackTimer += Time.deltaTime;

        controller.Move(horizontal * Time.fixedDeltaTime * moveSpeed, false, ifJump);
        
        if (dashSpeed>1)
            controller.Dash(lastHorizontal, dashMultiplier);
        ifJump = false;
        
        
    }
}
