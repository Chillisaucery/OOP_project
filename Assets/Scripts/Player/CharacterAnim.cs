using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    //Public
    public Animator animator;
    public CharacterMovement movement;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If the character move (horizontal != 0), apply the running animation
        if (movement.horizontal!=0)
            animator.SetBool("isRunning", true);
        else animator.SetBool("isRunning", false);

        //If the character is NOT grounded, apply the jumping/falling animation
        if (controller.m_Grounded == false)
            animator.SetBool("isJumping", true);
        else animator.SetBool("isJumping", false);

        //The same for the dash
        if (movement.dashSpeed > 1)
            animator.SetBool("isDashing", true);
        else
        {
            animator.SetBool("isDashing", false);
        }

        //The same for the attacking
        animator.SetBool("isAttacking", movement.isAttacking);
        
    }
}
