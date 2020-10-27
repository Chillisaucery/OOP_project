using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    //Public
    public Animator animator;
    public CharacterMovement movement;
    public CharacterController controller;

    //Private

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If the character move (horizontal != 0), apply the running animation
        if (movement.getHorizontal()!=0)
        {   
            animator.SetBool("isRunning", true);
        }
        else animator.SetBool("isRunning", false);

        //If the character is NOT grounded, apply the jumping/falling animation
        if (controller.getIfGrounded() == false)
            animator.SetBool("isJumping", true);
        else animator.SetBool("isJumping", false);

        //The same for the dash
        if (movement.getDashSpeed() > 1)
            animator.SetBool("isDashing", true);
        else
        {
            animator.SetBool("isDashing", false);
        }

        //The same for the attacking
        if (movement.getIsAttacking() == true)
        {
            animator.SetFloat("runningTimer", 1f);
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetFloat("runningTimer", 0f);
            animator.SetBool("isAttacking", false);
        }


    }
}
