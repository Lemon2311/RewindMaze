using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deleteEnemy : MonoBehaviour
{
    private bool canCollideWithEnemyToDestroy;
    private Spawn spawnData;

    private void Start()
    {
        spawnData = GameObject.FindWithTag("Spawner").GetComponent<Spawn>();
    }

    private void Update()
    {
        if (GameObject.FindWithTag("enemy") != null)
            Invoke("allawCollideDestroy", 1f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        
        if (!canCollideWithEnemyToDestroy)
            return;

        if (collision.gameObject.name == "enemy Variant(Clone)")
        {
            Destroy(GameObject.FindWithTag("enemy"));
            canCollideWithEnemyToDestroy = false;
            spawnData.wasInstantiated = false;
        }
    }

    void allawCollideDestroy()
    {
        canCollideWithEnemyToDestroy = true;
    }
}