using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    private Transform target;

    /*public float speed = 4f;*/
    Rigidbody rig;

    private bool isEnabled = true;
    private NavMeshAgent agent;

    public bool hasCollided;

    public string sceneName;
    public Animator anim;

    public Spawn spawnData;

    private AudioSource music;
    public AudioSource deadsound;


    // Start is called before the first frame update
    void Start()
    {
        spawnData = GameObject.FindWithTag("Spawner").GetComponent<Spawn>();

        music = GameObject.FindWithTag("music").GetComponent<AudioSource>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;

        /*agent.destination = target.position;*/

        rig = GetComponent<Rigidbody>();
    }

    void DestroyIfNeeded()
    {
        switch (spawnData.random)
        {
            case 0:
                if (transform.position == spawnData.spawn11.position) ;
                DestroyObject(gameObject);
                break;

            case 1:
                if (transform.position == spawnData.spawn22.position) ;
                DestroyObject(gameObject);
                break;

            case 2:
                if (transform.position == spawnData.spawn33.position) ;
                DestroyObject(gameObject);
                break;

            case 3:
                if (transform.position == spawnData.spawn44.position) ;
                DestroyObject(gameObject);
                break;


            default:
                Debug.Log("ce l am rupt pe pill #ill");

                break;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        /*Invoke("DestroyIfNeeded",1f);*/

        if (isEnabled == false)
            return;

        /*Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);

        agent.SetDestination(pos);*/

        if (agent.enabled)
            agent.SetDestination(target.position);


        //transform.LookAt(target);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "shadow1(Clone)")
        {
            music.volume -= 100;

            deadsound.Play();
            
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            // LoadScene();
            isEnabled = false;

            hasCollided = true;

            anim.SetTrigger("jumpTrig");
        }

        /*switch (spawnData.random)
        {
            case 1 : 
                if (collision.gameObject.name == spawnData.spawn11.name)
                    DestroyObject(gameObject);
                break;
            
            
            case 2 : 
                if (collision.gameObject.name == spawnData.spawn22.name)
                    DestroyObject(gameObject);
                break;
            
            
            case 3 : 
                if (collision.gameObject.name == spawnData.spawn33.name)
                    DestroyObject(gameObject);
                break;
            
            
            case 4 : 
                if (collision.gameObject.name == spawnData.spawn44.name)
                    DestroyObject(gameObject);
                break;
        }*/
    }

    private void LoadScene()
    {
        Debug.Log("sceneName to load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    void LateUpdate()
    {
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
    }
}