using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTurn : MonoBehaviour
{
    //İs have to be component with camera

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Rotater");

        GetComponent<CameraFollow>().enabled = false;

    }

    private void Update()
    {

        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.right * Time.deltaTime);
    }


}
