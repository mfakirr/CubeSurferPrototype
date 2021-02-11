using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Move move = default;

    GameManager gm = default;
    void Start()
    {
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();

        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cubes" || other.gameObject.tag == "FirstCube")
        {
            move.Speed = 10;
            gm.PowerUpSound();
            Invoke("decreaseSpeed", 1);

        }
    }
    void decreaseSpeed()
    {
        move.Speed = 4;
        
        gameObject.SetActive(false);
    }
}
