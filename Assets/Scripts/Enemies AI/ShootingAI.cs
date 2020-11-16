using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    public Shooting shooting;
    public float cooldown = 0.5f;
    private float timer = 0;
    private bool shouldShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shouldShoot = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shouldShoot = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (shouldShoot)
        {
            if (timer > cooldown)
            {
                timer = 0;
                shooting.Shoot(false);
            }
            else timer += Time.deltaTime;
        }
            
    }

    
}
