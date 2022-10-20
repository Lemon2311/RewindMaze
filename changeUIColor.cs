using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeUIColor : MonoBehaviour
{
    public GameObject text0;
    public GameObject text1;
    public GameObject text2;

    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        Color color = color = materials[(int)Random.Range(0,materials.Length)].color;

        text0.GetComponent<TextMeshProUGUI>().color = color;
        text1.GetComponent<TextMeshProUGUI>().color = color;
        text2.GetComponent<TextMeshProUGUI>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
