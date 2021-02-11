using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    GameManager gm = default;

    public byte multiplier=0;

    private GameObject inDestroy = default;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        inDestroy = other.gameObject;
        if (inDestroy.tag == "FirstCube")
        {
            gm.endLineMultiplier = multiplier;

            StartCoroutine(WaitForDoİt(true));
             
        }
        else if (inDestroy.tag == "Cubes")
        {
            gm.RemoveTheList(inDestroy);

            StartCoroutine(WaitForDoİt(false));

            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator WaitForDoİt(bool Door)
    {
       
        yield return new WaitForSecondsRealtime(0.5f);
        if (Door)
        {
            gm.WinTheLevel();
        }
        else
        {
            Destroy(inDestroy);
        }
        
    }
}
