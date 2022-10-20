using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenRewindMaze : MonoBehaviour
{
    
    void Update()
    {
        if (transform.position.y <= -1100)
            transform.position += new Vector3(0, 1620, 0);
    }
}
