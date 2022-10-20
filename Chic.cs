using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -700)
            transform.position += new Vector3(0, 1220, 0);
        
        transform.Rotate (10*Time.deltaTime,10*Time.deltaTime,10*Time.deltaTime);
    }
}
