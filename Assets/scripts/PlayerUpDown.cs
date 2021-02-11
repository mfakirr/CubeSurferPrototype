using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpDown : MonoBehaviour
{
    public void GoUp()
    {
        float changeY = transform.localPosition.y + 0.7f;
        transform.localPosition = new Vector3(0, changeY , 0);
      
    }

}
