using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameManager gm = default;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject What = collision.gameObject;
        if (What.tag == "Cubes" && gm.IsThatSameYummys(What))
        {
            //Debug.Log("girdi");
            //
            gm.moveYummysUp();    //move yummys up whatever is on the list
            //
            
            gm.MoveMyNewYummyBase(What);

            //do it child because it travel with us, move the base, add the list because it is joining us

        }
        else if (What.tag == "MMs")
        {
            gm.EatTheMMs();
            What.SetActive(false);//mms eat it
            //Destroy(What);

        }

    }


}
