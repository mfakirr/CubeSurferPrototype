using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BegginingElements : MonoBehaviour
{

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
