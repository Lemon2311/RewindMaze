using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTrackOfLevel : MonoBehaviour
{
    [SerializeField]
    public int level = 1;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
}
