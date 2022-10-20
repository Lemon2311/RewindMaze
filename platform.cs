using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{

    private platformManager platformManager;

    private void OnEnable()
    {
        platformManager = GameObject.FindObjectOfType<platformManager>();
    }


    private void OnBecameInvisible()
    {
        //recycle unseen platform 
        platformManager.recyclePlatform(this.gameObject);

    }


}
