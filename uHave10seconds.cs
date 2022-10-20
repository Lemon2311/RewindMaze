using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uHave10seconds : MonoBehaviour
{

    public float y = 10f;
    public Canvas end;

    void Start()
    {
        end.enabled = false;
    }

    
    void Update()
    {
        y -= Time.deltaTime;

        if (y <= 0)
            end.enabled = true;
        
            

    }
}
