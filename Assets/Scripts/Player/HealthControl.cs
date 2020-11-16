using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    public float health = 100f;
    public bool isDamaged = false;

    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Take damage (or receive heal)
    public void TakeDamage (float damage)
    {

        if (health - damage <=100 || damage>0) 
            health -= damage;
        if (health<=0)
        {
            Die();
        }
        if (damage>0)
            isDamaged = true;
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
