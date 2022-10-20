using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUi : MonoBehaviour
{
    public GameObject nUI;
    public GameObject eUI;
    public int UISet = 0;
    public GameObject playerButtons;
    public GameObject enemyObj;
    public enemyScript enemyScript;
    private bool wasInvoked;

    // Start is called before the first frame update
    void Start()
    {
        nUI = GameObject.FindWithTag("NUI");
        nUI.SetActive(true);

        eUI = GameObject.FindWithTag("EUI");
        eUI.SetActive(false);

        playerButtons = GameObject.FindWithTag("PB");
        playerButtons.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //fixed enemy doesn`t exist for 2 seconds

        if (GameObject.FindGameObjectWithTag("enemy") != null && UISet == 0)
        {
            Invoke("SetUI", 0f);
            UISet++;
        }

        if (GameObject.FindGameObjectWithTag("enemy") == null)
            UISet = 0;

        Invoke("SetNui",1f);

        if (!wasInvoked)
            return;


        if (enemyScript.hasCollided)
        {
            eUI.SetActive(true);
            nUI.SetActive(false);
            playerButtons.SetActive(false);
        }
    }

    void SetUI()
    {
        enemyObj = GameObject.FindGameObjectWithTag("enemy");
        enemyScript = enemyObj.GetComponent<enemyScript>();

        wasInvoked = true;
    }

    void SetNui()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            eUI.SetActive(true);
            nUI.SetActive(false);
            playerButtons.SetActive(false);
        }
    }
}