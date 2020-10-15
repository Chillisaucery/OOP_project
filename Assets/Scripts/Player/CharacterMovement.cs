using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //Public
    public CharacterController controller;
    public float moveSpeed = 40f;
    public float horizontal = 0f;
    public bool ifJump = false;

    public float dashRecharge = 1f;
    private float rechargeTimer = 0f;
    public float dashMultiplier = 10;
    public float dashDuration = 1.0f;
    private float dashTimer = 0f;
    public float dashSpeed = 1f;

    public bool isAttacking = false;
    public float attackDuration = 1f;
    private float attackTimer = 0f;

    //Variables
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
            ifJump = true;
        if (Input.GetButtonDown("Dash"))
            dashSpeed = dashMultiplier;
        if (Input.GetButtonDown("Attack"))
            isAttacking = true;

    }

    void FixedUpdate()
    {
        if (dashTimer >= dashDuration)      //If the player dashed for enough time
        {
            dashSpeed = 1;
            dashTimer = 0;
        }
        else dashTimer = dashTimer + Time.deltaTime;

        if (rechargeTimer >= dashRecharge)
            rechargeTimer = 0;
        else rechargeTimer = rechargeTimer + Time.deltaTime;

        if (attackTimer >= attackDuration)
        {
            attackTimer = 0;
            isAttacking = false;
        }
        else attackTimer = attackTimer + Time.deltaTime;

        controller.Move(horizontal * dashSpeed * Time.fixedDeltaTime * moveSpeed, false, ifJump);
        ifJump = false;
        
        
    }
}
