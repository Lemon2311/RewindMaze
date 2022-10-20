using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefabs;
   
    private int zOffset;
    

    void Start()
    {
        for(int i=0;i<platformPrefabs.Length;i++)
        {
            Instantiate(platformPrefabs[i], new Vector3(0, 0, i * 10), Quaternion.Euler(0, 0, 0));
            zOffset += 10;
        }


    }

    
    public void recyclePlatform(GameObject platform)
    {
        platform.transform.position = new Vector3(0, 0, zOffset);
        zOffset += 10;
    }
}
