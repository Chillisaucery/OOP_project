using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger2D : MonoBehaviour
{
    private bool ifTriggered = false;

    public bool GetTrigger()
    {
        return (ifTriggered);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ifTriggered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ifTriggered = false;
    }

    public void Update()
    {
        Debug.Log("If triggered: " + ifTriggered);
    }
}
