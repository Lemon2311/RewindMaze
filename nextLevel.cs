using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{ 
    [SerializeField]
    public string sceneName;

    [SerializeField]
    public float y;

    [SerializeField]
    public bool isTimed;

    public KeepTrackOfLevel levelComponent;

    void Start()
    {
        GameObject levelCounterObj = GameObject.FindGameObjectWithTag("levelCount");
        levelComponent = levelCounterObj.GetComponent<KeepTrackOfLevel>();

        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (y <= 0 && isTimed) return;

        if (collision.gameObject.name == "shadow1(Clone)")
        {
            LoadScene();
            
            levelComponent.level++;
        }


    }



    private void LoadScene()
    {
        Debug.Log("sceneName to load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    void FixedUpdate()
    {
        

        if (Input.GetKey(KeyCode.C))
            y += Time.deltaTime;
       else
        y -= Time.deltaTime;
    }
}
