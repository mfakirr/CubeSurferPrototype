using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosCal : MonoBehaviour
{
    //İs have to be component with camera
    [SerializeField]
    private Vector3 mousePos;
    [SerializeField]
    private float mousePosX = 0;
    [SerializeField]
    private float firstMousePos = 0;
    [SerializeField]
    private float posChangeX = 0;


    public float positionChangingX
    {
        get
        {
          
                return -posChangeX;
           
           
        }
    }

    void Update()
    {
        mousePosCalculator();//Calculate the mouse pos real pos
        //
        if (Input.GetMouseButtonDown(0))
        {  firstMousePos = mousePosX;   }//get first mouse position

        //

        if (Input.GetMouseButton(0))
        {   posChangeX = firstMousePos - mousePosX;   }//get changing real mouse pos

        //

        if(Input.GetMouseButtonUp(0)) 
        {   posChangeX =0; }

    }

    void mousePosCalculator()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -3.5f;//manuel
        mousePosX = Camera.main.ScreenToWorldPoint(mousePos).x;
    }



}
