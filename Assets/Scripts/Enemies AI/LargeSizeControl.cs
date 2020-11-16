using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeSizeControl : MonoBehaviour
{
    private Transform transform;
    private HealthControl health;
    public float sizeMultiplier = 2f;
    public float healthMultiplier = 2f;


    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        health = GetComponent<HealthControl>();
        transform.localScale+= new Vector3 (sizeMultiplier, sizeMultiplier, 1);
        health.health *= healthMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
