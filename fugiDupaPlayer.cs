using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fugiDupaPlayer : MonoBehaviour
{
    public float speed;
    public Transform target;
    float x;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime;
        if (x == 3) target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
}
