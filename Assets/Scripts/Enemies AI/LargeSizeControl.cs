using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeSizeControl : MonoBehaviour
{
    private Transform transform;
    private HealthControl healthControl;
    public float sizeMultiplier = 2f;
    public float healPerSecond = 1f;
    public float healthMultiplier = 2f;


    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        healthControl = GetComponent<HealthControl>();
        transform.localScale+= new Vector3 (sizeMultiplier, sizeMultiplier, 1);
        healthControl.health *= healthMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        healthControl.TakeDamage(-1 * healPerSecond);
    }
}
