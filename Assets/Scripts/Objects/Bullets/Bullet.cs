using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
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

        HealthControl target = collision.GetComponent<HealthControl>();

        if (target != null)
        {
            target.TakeDamage(damage);
        }

        if (collision.name != "ElectricBullet(Clone)")
            Destroy(gameObject);

    }
}
