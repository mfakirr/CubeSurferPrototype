using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTheLevel : MonoBehaviour
{
    GameManager gm = default;

    bool a;

    public byte multiplier = 0;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();


    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject control = other.gameObject;

        if (control.tag == "FirstCube" || control.tag == "Cubes")
        {
            gm.endLineMultiplier = multiplier;
            gm.WinTheLevel();

        }

    }




    }
