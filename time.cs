using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    public float timez;
    private KeepTrackOfLevel levelS;
    private bool isEnabled;
    private float trueTimez = 15;
    public AudioSource clip;
    private bool wasInvoked;
    public AudioSource music;
    private float times;

    // Start is called before the first frame update
    void Start()
    {
        levelS = GameObject.FindWithTag("levelCount").GetComponent<KeepTrackOfLevel>();
        trueTimez += (int) levelS.level / 5 * 5;
        timez += (int) levelS.level / 5 * 5;
        music = GameObject.FindWithTag("music").GetComponent<AudioSource>();
    }

    public void enable()
    {
        isEnabled = true;
    }

    public void disable()
    {
        isEnabled = false;
    }

    void PlayerNUll()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            wasInvoked = true;
            music.volume = 0;
        }
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Player") == null)
            music.volume -=Time.deltaTime;

        times += Time.deltaTime;
        
        if(times>1)
            PlayerNUll();

        if (timez <= 3 && !wasInvoked)
        {
            clip.Play();
            wasInvoked = true;
        }


        if (timez <= 3 || wasInvoked)
            music.volume -= Time.deltaTime / 2;
        else
        {
            music.volume = 1;
        }


        if (timez > trueTimez)
            timez = trueTimez;

        if (timez <= 0)
        {
            timez = 0;
            Destroy(GameObject.FindWithTag("Player"));
        }

        if (!isEnabled)
            timez -= Time.deltaTime;
        else
            timez += Time.deltaTime;
    }
}