using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    [SerializeField]
    public string sceneName;
    public TextMeshProUGUI text;
    public RewindTime rewind;
    public KeepTrackOfLevel levelScript;
    public bool restart;
    
    // Start is called before the first frame update
    void Start()
    {
        levelScript = GameObject.FindWithTag("levelCount").GetComponent<KeepTrackOfLevel>();
        rewind = GameObject.FindWithTag("RewindTime").GetComponent<RewindTime>();
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    private void LoadScene()
    {
        if (restart)
        {
            levelScript.level = 1;
            rewind.time = 10;
        }

        Debug.Log("sceneName to load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void Restart(){

         LoadScene();

    }
}
