using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timeDown : MonoBehaviour
{

    TextMeshProUGUI text;
    [SerializeField]
    float x = 10f;

    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = x + "";
      
        if (Input.GetKey(KeyCode.C))
            x += Time.deltaTime;
        else
        {

            

            x -= Time.deltaTime;
          
            if (x <= 0)
            {
                x = 0;
                text.text = x + " r=restart";
            }
        }
    }
}
