using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class timeBody : MonoBehaviour
{
    public bool isRewinding = false;

    public bool isRb;

    public RewindTime rewindTime;
    
    public float recordTime = 100f;

    List<pointInTime> pointsInTime;

    Rigidbody rb;

    void Start()
    {
        pointsInTime = new List<pointInTime>();
        
        if(isRb)
        rb = GetComponent<Rigidbody>();

        GameObject rewindTimeObject = GameObject.FindGameObjectWithTag("RewindTime");
        rewindTime = rewindTimeObject.GetComponent<RewindTime>();
    }

    
    void Update()
    {
        if (GameObject.Find("shadow1(Clone)") == null)
            return;

            // if (Input.GetKeyDown(KeyCode.C))
            // startRewind();

            // if(Input.GetKeyUp(KeyCode.C))
            // stopRewind();

        if (rewindTime.time <= 0)
            isRewinding = false;


            
    }

    private void FixedUpdate()
    {
        if (isRewinding)
            rewind();
        else
            Record();
    }

    private void Record()
    {

        if(pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }    

        pointsInTime.Insert(0, new pointInTime(transform.position , transform.rotation));
    }

    public void rewind()
    {
        if(pointsInTime.Count > 0) 
        {
            pointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        
        }
        else
        {
            stopRewind();
        }
        
    }

    public void stopRewind()
    {
        isRewinding = false;

        if (isRb)
            rb.isKinematic = false;
    }

    public void startRewind()
    {
        isRewinding = true;

        if (isRb)
            rb.isKinematic = true;
    }
}
