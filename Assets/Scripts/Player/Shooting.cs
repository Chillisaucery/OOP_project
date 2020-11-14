using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform busterPoint;
    public GameObject bulletPrefab;
    public GameObject alterBullet;
    public GameObject shooter;
    public float recoil = 2f;
    public float offset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(bool ifAlter)
    {
        //Calculate the position
        Vector3 firingPosition = new Vector3(busterPoint.position.x + offset*transform.right.x, busterPoint.position.y, busterPoint.position.z); 

        //Shoot the bullet
        if (!ifAlter)
        { 
            Instantiate(bulletPrefab, firingPosition, busterPoint.rotation); 
        }
        else
        {
            Instantiate(alterBullet, firingPosition, busterPoint.rotation);
        }

            //Get the component
            Rigidbody2D rb = shooter.GetComponent<Rigidbody2D>();

        //Make the recoil
        rb.AddForce(new Vector2(recoil * transform.right.x * -1, 0), ForceMode2D.Impulse);

    } 
}
