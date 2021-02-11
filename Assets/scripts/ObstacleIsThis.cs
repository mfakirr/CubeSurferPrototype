using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleIsThis : MonoBehaviour
{
    GameManager gm = default;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            transform.parent.gameObject.transform.SetParent(null);
            gm.RemoveTheList(transform.parent.gameObject);
        }
    }
}
