using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedAI : MonoBehaviour
{
    //Other component
    public CharacterController controller;
    public Transform frontCheck;
    [SerializeField] private LayerMask WhatIsVerge;

    //Walking
    public float moveSpeed = 20f;
    private float horizontal = 0f;

    //Constant
    const float k_GroundedRadius = .2f;

    //Private
    //If the monster hit the verge
    private bool ifHitVerge = false;

    //Getter setter
    public float getHorizontal()
    {
        return horizontal;
    }

    // Start is called before the first frame update
    private void Start()
    {
        horizontal = 1f;
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(frontCheck.position, k_GroundedRadius, WhatIsVerge);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                ifHitVerge = true;
            }
        }

        // Flip the the facing direction of the component
        if (ifHitVerge)
        {
            horizontal *= -1;
        }

        controller.Move(horizontal * Time.fixedDeltaTime * moveSpeed, false, false);
    }

}
