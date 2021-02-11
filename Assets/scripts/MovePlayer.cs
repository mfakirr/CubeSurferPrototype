using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    MousePosCal mousePosCal=default;

    Rigidbody   Rb=default;

    float       beforeChangingX = default;
    float       afterChanginX = default;
    float       sumChangingX = default;
    float       positionX = default;
    
   
    void Start()
    {
        transform.position = Vector3.zero;

        Rb = GetComponent<Rigidbody>();

        mousePosCal = Camera.main.GetComponent<MousePosCal>();

       
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            beforeChangingX = mousePosCal.positionChangingX;//before move
            //
            sumChangingX = beforeChangingX - afterChanginX ;//mouse pos changing per frame
            //
            positionX = transform.position.x - sumChangingX;//where am i
            //
            if (positionX <= 1.5f && positionX >= -1.5f )
            {
               
                //
                transform.position = new Vector3(transform.position.x-sumChangingX,
                    transform.position.y, transform.position.z); //change position  
                //
            }
            //
          afterChanginX = mousePosCal.positionChangingX;//after move
        }
        else
        {
            afterChanginX = 0; beforeChangingX = 0;
        }
    }




}
