using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    float time;
    public int x=0;
    public TextMeshProUGUI text;

    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = x.ToString();

        time += Time.deltaTime;

        if (time >= 10)
        {
            time = 0;
            x++;
        }
    }
}
