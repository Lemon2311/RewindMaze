using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontDestroy : MonoBehaviour
{
    public string tag;
    AudioSource audioSource;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void RewindSound(){   

       
            audioSource.pitch = -1;
            Time.timeScale = 0.6f;
       
           
        

        

    }

    public void WindSound(){
            
            audioSource.pitch = 1;
            Time.timeScale = 1;
    }

    


}
