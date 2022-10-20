using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnemyAttack : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        /*Debug.Log(collision.gameObject.name);*/
        
        if(collision.gameObject.tag == "enemy")
        {
              DestroyObject(gameObject);
              GameObject.FindGameObjectWithTag("music").GetComponent<DontDestroy>().WindSound();
        }
         

        /*Debug.Log(collision);*/
       
    }

}
