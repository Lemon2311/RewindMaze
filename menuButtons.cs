using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("poti sa iesi");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGAme()
    {
        Debug.Log("quit!");
        Application.Quit();

    }
}
