using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float damage;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Deal Damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        //Get the components from the target
        HealthControl targetHealth = collision.GetComponent<HealthControl>();
        Rigidbody2D targetBody = collision.GetComponent<Rigidbody2D>();

        //Deal damage to the target
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        //Make the target fall back
        targetBody.AddForce(new Vector2(force*targetBody.transform.right.x*-1, force/10), ForceMode2D.Impulse);

    }
}
