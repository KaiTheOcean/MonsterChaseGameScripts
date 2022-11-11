using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;

    private int minX = -60;
    private int maxX = 60;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(!player)
        {
            // If the condition is met then skip the following
            return; // Meaning if player == null
        }

        tempPos = transform.position; // this is the current position of the camera
        tempPos.x = player.position.x; //set the tempPos x to the player position x

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }

        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }

        transform.position = tempPos;
    }
}
