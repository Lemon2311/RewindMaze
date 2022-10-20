using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keepTrackOfTime : MonoBehaviour
{
    private time time;
    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject rewindTimeObject = GameObject.FindGameObjectWithTag("gameM");
        time = rewindTimeObject.GetComponent<time>();
    }
    

    // Update is called once per frame
    void Update()
    {
        text.text = "Time : " + (float)Math.Round(time.timez);
    }
}
