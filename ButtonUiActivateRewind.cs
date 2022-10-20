using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUiActivateRewind : MonoBehaviour
{
    int i = 1;

    public time time;

    private void Start()
    {
        time = GameObject.Find("gameManager").GetComponent<time>();
    }

    public void ActivateRewind()
    {
        time.enable();

        if (GameObject.Find("shadow1(Clone)") == null)
            return;

        GameObject.FindGameObjectWithTag("Player").GetComponent<timeBody>().startRewind();
        GameObject.FindGameObjectWithTag("music").GetComponent<DontDestroy>().RewindSound();


        if (GameObject.FindGameObjectWithTag("enemy") == null)
            return;

        GameObject.FindGameObjectWithTag("enemy").GetComponent<timeBody>().startRewind();
    }

    public void DeactivateRewind()
    {
        time.disable();

        if (GameObject.Find("shadow1(Clone)") == null)
            return;

        GameObject.FindGameObjectWithTag("music").GetComponent<DontDestroy>().WindSound();
        GameObject.FindGameObjectWithTag("Player").GetComponent<timeBody>().stopRewind();

        if (GameObject.FindGameObjectWithTag("enemy") == null)
            return;

        GameObject.FindGameObjectWithTag("enemy").GetComponent<timeBody>().stopRewind();
    }
}