using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;

    float startPosZ;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

       startPosZ =  transform.position.z;
    }

 
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x,
            transform.position.y,startPosZ+player.position.z);
    }
}
