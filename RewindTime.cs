using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
   public float time =20f;

   public bool isRewinding;

   void FixedUpdate()
   {
     if (isRewinding)
        time-=Time.deltaTime;
    
     if (time <= 0) 
         time = 0;
   }

   void Awake()
   {
       DontDestroyOnLoad(this.gameObject);
   }
   
   
}
