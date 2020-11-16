using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public float force = 200f;
    private Rigidbody2D rb;
    public GameObject onDestroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //On trigger (currently only trigerred by the 2D collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        HealthControl targetHealth = collision.GetComponent<HealthControl>();

        //Animate the effect when being destroyed
        Instantiate(onDestroyEffect, transform.position, transform.rotation);

        //Deal damage to the target
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
            if (!collision.GetComponent<Bullet>())
                Destroy(gameObject);
        }

        //Make the target fall back
        //Rigidbody2D targetBody = collision.GetComponent<Rigidbody2D>();
        //targetBody.AddForce(new Vector2(force*transform.right.x, 0), ForceMode2D.Impulse);

        

    }
}
