using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
 
    bool a =false;
    [HideInInspector]
    public float Speed = 0.1f;


    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) || a)
        {
            transform.position += Vector3.forward * Speed * Time.deltaTime;
            a = true;
        }
    }
}
