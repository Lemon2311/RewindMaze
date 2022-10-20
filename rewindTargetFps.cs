

using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public float range=100f;
   /* public float time = 0f;
    public float timeOfRewind = 5f;*/

    /* public float damage=10f;*/

    /*public AudioSource audios;
   
    
    public float meleRange = 3f;
    public Animator animat;
    public AudioSource reloadS;
    public Text Ammo;
    public float durataLovSabie = 1f;
    public AudioSource noAmmo;

    
    public ParticleSystem muzzleFlash;
    
     public int clip=6;
      private int clips;
     private int clipSize = 0;
    float reloadTime=1f;*/




    void Update()
    {
      /*  Ammo.text = clip.ToString()+"/"+clips.ToString();*/

        
        
            if (Input.GetButtonDown("Fire1"))
            {

                Shoot();

            }
        
        

           
        

    /*    if (Input.GetKeyDown(KeyCode.R))
        { 
            reloadTime = 0f;
            clip = clips;
            reloadS.Play();
            animat.SetTrigger("son");

        }*/
/*
        durataLovSabie += Time.deltaTime;

        if (Input.GetButtonDown("Fire2"))
        {


            if (durataLovSabie >= 1f) { 

            mele();

               }

            

        }*/
        
        

        
    }

    void Shoot()
    {
      

        

       
        
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                timeBody target = hit.transform.GetComponent<timeBody>();
                if (target != null)
                {

                target.isRewinding = true;
                
               

                
                    

                



                }



            }
        
        
    }

  /*  void mele()
    {

        durataLovSabie = 0f;
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, meleRange))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);

            }


        }
        
        

        
        
    }*/

}
