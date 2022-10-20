using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableRewind : MonoBehaviour
{
    private RewindTime rewindTime;
    public int timeAddedByCoin;
    
    // Start is called before the first frame update
    void Start()
    {
       rewindTime = GameObject.FindWithTag("RewindTime").GetComponent<RewindTime>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "shadow1(Clone)")
        {
            rewindTime.time += timeAddedByCoin;
            Destroy(gameObject);

        }

    }
}
