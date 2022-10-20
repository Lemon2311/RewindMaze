using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShowRewindTimeRemaining : MonoBehaviour
{
    private RewindTime rewindTime;
    public TextMeshProUGUI rewindText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject rewindTimeObject = GameObject.FindGameObjectWithTag("RewindTime");
        rewindTime = rewindTimeObject.GetComponent<RewindTime>();
    }
    

    // Update is called once per frame
    void Update()
    {
        rewindText.text = "Rewind " + (float)Math.Round(rewindTime.time);
    }
}                        
