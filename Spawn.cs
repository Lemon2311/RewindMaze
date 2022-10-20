using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelCollider;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject enemyCollider;

    public MazeLoader mazeLoader;

    public KeepTrackOfLevel levelNr;

    public GameObject levelNrObj;

    public float distance = 33.3f;

    public float trueDistance = 0;

    public bool isDone;

    public float spawnCoinPlacex;
    [FormerlySerializedAs("spawnCoinPlacey")] public float spawnCoinPlacez;

    [SerializeField] private GameObject follower;

    public int offset = 4;

    public bool wasInstantiated;

    public Vector3 vectorOFfset = new Vector3(0, 4, 0);

    private float initX = 33f, initY = 3, initZ = 33f, marj = 33;

    public int random;

    public GameObject coin;

    [FormerlySerializedAs("spawn0")] public Transform spawn44;
    [FormerlySerializedAs("spawn1")] public Transform spawn22;
    [FormerlySerializedAs("spawn2")] public Transform spawn33;
    [FormerlySerializedAs("spawn3")] public Transform spawn11;

    void Start()
    {
        mazeLoader = GameObject.FindWithTag("gameM").GetComponent<MazeLoader>();

        levelNrObj = GameObject.FindWithTag("levelCount");
        levelNr = levelNrObj.GetComponent<KeepTrackOfLevel>();

        /*initX+= levelNr.level/5*10;
        initY+= levelNr.level/5*5;
        initZ+= levelNr.level/5*10;*/

        random = Random.Range(1, 5);


        /*EXSpawn();*/

        Invoke("FindSpwanPoints", 0.1f);

        Invoke("SpawnPlayerAndNextLevelCollider", 0.2f);

        SpawnCoins(Random.Range(1+levelNr.level/10, 3+levelNr.level/10));
        
        Invoke("Done", 0.2f);
    }

    void Done()
    {
        isDone = true;
    }


    void Update()
    {
        if (isDone)
        {
            Invoke("SpawnFollower", 0.1f);
        }

        // if (mazeLoader.isInitialized)
        // {

        // }
    }


    void FindSpwanPoints()
    {
        spawn44 = GameObject.Find("Floor " + (mazeLoader.mazeRows - 1) + "," + (mazeLoader.mazeColumns - 1)).transform;

        spawn22 = GameObject.Find("Floor " + (mazeLoader.mazeRows - 1) + "," + 0).transform;

        spawn33 = GameObject.Find("Floor " + 0 + "," + (mazeLoader.mazeColumns - 1)).transform;

        spawn11 = GameObject.Find("Floor " + 0 + "," + 0).transform;
    }
    
    void SpawnCoins(int n)
    {
        for (int i = 0; i < n; i++)
        {

            spawnCoinPlacez = Random.Range(0, mazeLoader.mazeRows - 1);
            spawnCoinPlacex = Random.Range(0, mazeLoader.mazeColumns - 1);

            Vector3 vector3 = GameObject.Find("Floor " + ((int) spawnCoinPlacez) + "," + ((int) spawnCoinPlacex))
                .transform
                .position;

            Instantiate(coin, vector3 + vectorOFfset, Quaternion.Euler(0, 0, 0));

        }

    }


    void SpawnPlayerAndNextLevelCollider()
    {
        if (random == 1)
        {
            Instantiate(target, spawn44.position + vectorOFfset * 2, Quaternion.Euler(90, 0, 0));
            Instantiate(nextLevelCollider, spawn44.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
            Instantiate(player, spawn11.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
            Instantiate(enemyCollider, spawn11.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
        }

        if (random == 2)
        {
            Instantiate(target, spawn33.position + vectorOFfset * 2, Quaternion.Euler(90, 0, 0));
            Instantiate(nextLevelCollider, spawn33.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
            Instantiate(player, spawn22.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
            Instantiate(enemyCollider, spawn22.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
        }

        if (random == 3)
        {
            Instantiate(target, spawn22.position + vectorOFfset * 2, Quaternion.Euler(90, 0, 0));
            Instantiate(nextLevelCollider, spawn22.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
            Instantiate(player, spawn33.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
            Instantiate(enemyCollider, spawn33.position +vectorOFfset, Quaternion.Euler(0, 0, 0));
        }

        if (random == 4)
        {
            Instantiate(target, spawn11.position + vectorOFfset * 2, Quaternion.Euler(90, 0, 0));
            Instantiate(nextLevelCollider, spawn11.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
            Instantiate(player, spawn44.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
            Instantiate(enemyCollider, spawn44.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
        }
    }


    void SpawnFollower()
    {
        if(GameObject.FindWithTag("Player")==null)
            return;

        if (random == 1)
        {
            trueDistance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, spawn11.position);
            if (trueDistance > distance && !wasInstantiated)
            {
                Instantiate(follower, spawn11.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
                wasInstantiated = true;
            }
            /*else if (GameObject.FindWithTag("enemy") != null)
            {
                DestroyObject(follower);
                wasInstantiated = false;
            }*/
        }


        if (random == 2)
        {
            trueDistance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, spawn22.position);
            if (trueDistance > distance && !wasInstantiated)
            {
                Instantiate(follower, spawn22.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
                wasInstantiated = true;
            }
            /*else if (GameObject.FindWithTag("enemy") != null)
            {
                DestroyObject(follower);
                wasInstantiated = false;
            }*/
        }


        if (random == 3)
        {
            trueDistance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, spawn33.position);
            if (trueDistance > distance && !wasInstantiated)
            {
                Instantiate(follower, spawn33.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
                wasInstantiated = true;
            }
            /*else if (GameObject.FindWithTag("enemy") != null)
            {
                DestroyObject(follower);
                wasInstantiated = false;
            }*/
        }

        if (random == 4)
        {
            trueDistance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, spawn44.position);
            if (trueDistance > distance && !wasInstantiated)
            {
                Instantiate(follower, spawn44.position + vectorOFfset, Quaternion.Euler(0, 0, 0));
                wasInstantiated = true;
            }
            /*else if (GameObject.FindWithTag("enemy") != null)
            {
                DestroyObject(follower);
                wasInstantiated = false;
            }*/
        }
    }

   
    void EXSpawn()
    {
        /*if (random == 1)
       {
            Instantiate(target, new Vector3(initX,initY+offset,initZ), Quaternion.Euler(90, 0, 0));
            Instantiate(nextLevelCollider, new Vector3(initX, initY, initZ), Quaternion.Euler(0, 0, 0));
            Instantiate(player, new Vector3(initX-marj, initY, initZ-marj), Quaternion.Euler(0, 0, 0));
       }
       
       if (random == 2)
       {
           Instantiate(target, new Vector3(initX-marj, initY+offset, initZ), Quaternion.Euler(90, 0, 0));
           Instantiate(nextLevelCollider, new Vector3(initX-marj, initY, initZ), Quaternion.Euler(0, 0, 0));
           Instantiate(player, new Vector3(initX, initY, initZ-marj), Quaternion.Euler(0, 0, 0));
       }
       

       if (random == 3)
       {
           Instantiate(target, new Vector3(initX-marj, initY+offset, initZ-marj), Quaternion.Euler(90, 0, 0));
           Instantiate(nextLevelCollider, new Vector3(initX-marj, initY, initZ-marj), Quaternion.Euler(0, 0, 0));
           Instantiate(player, new Vector3(initX, initY, initZ), Quaternion.Euler(0, 0, 0));
       }

       if (random == 4)
       {
           Instantiate(target, new Vector3(initX, initY+offset, initZ-marj), Quaternion.Euler(90, 0, 0));
           Instantiate(nextLevelCollider, new Vector3(initX, initY, initZ-marj), Quaternion.Euler(0, 0, 0));
           Instantiate(player, new Vector3(initX-marj, initY, initZ), Quaternion.Euler(0, 0, 0));
       }*/
    }
}