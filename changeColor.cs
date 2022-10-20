using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{

    public Material[] materials;
    public MeshRenderer render;
    Object maze;

    void Start()
    {
        
        render.enabled = true;
        render.sharedMaterial = materials[0];
        maze = GameObject.FindGameObjectWithTag("Wall");
        render.sharedMaterial = materials[(int)Random.Range(0,materials.Length)];
    }



}
