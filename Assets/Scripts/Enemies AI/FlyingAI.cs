using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAI : MonoBehaviour
{
    //Other component
    public CharacterController controller;
    public Transform upperCheck;
    public Transform groundCheck;
    public Rigidbody2D rb;
    [SerializeField] private LayerMask WhatIsVerge;

    //Floating
    public float moveSpeed = 20f;
    private float vertical = 0f;
    public float floatingSpeed = 50f;


    //Constant
    const float k_GroundedRadius = .2f;

    //Private
    //If the monster hit the verge
    private bool ifHitVerge = false;

    //Getter setter
    public float getVertical()
    {
        return vertical;
    }

    // Start is called before the first frame update
    private void Start()
    {
        vertical = 1f;
    }

    // Update is called once per frame
    private void Update()
    {


    }


    private void FixedUpdate()
    {
        ifHitVerge = false;


        // The creature hit the verge if the frontCheck hits anything designated as Verge
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliderUpper = Physics2D.OverlapCircleAll(upperCheck.position, k_GroundedRadius, WhatIsVerge);
        for (int i = 0; i < colliderUpper.Length; i++)
        {
            if (colliderUpper[i].gameObject != gameObject)
            {
                ifHitVerge = true;
            }
        }

        // The creature hit the verge if the frontCheck hits anything designated as Verge
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliderLower = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, WhatIsVerge);
        for (int i = 0; i < colliderLower.Length; i++)
        {
            if (colliderLower[i].gameObject != gameObject)
            {
                ifHitVerge = true;
            }
        }


       

        // The creature hit the verge if the frontCheck hits anything designated as Verge
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.



        // Change the the direction of the component
        if (ifHitVerge)
        {
            vertical *= -1;
        }

        rb.velocity = new Vector2(0, vertical * floatingSpeed);
    }

}
