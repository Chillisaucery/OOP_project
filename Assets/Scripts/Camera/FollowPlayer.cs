using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object
    public float yOffset = 10f;
    public float zOffset = 10f;

    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, zOffset);

        // Set the position of the camera's transform to another place if the player die.
        if (!player)
            transform.position = Vector3.zero;
    }
}