using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepHighScore : MonoBehaviour
{
    public GameObject levelScoreObj;
    public KeepTrackOfLevel levelScript;
    public TextMeshProUGUI highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        levelScoreObj=GameObject.FindWithTag("levelCount");
        levelScript = levelScoreObj.GetComponent<KeepTrackOfLevel>();
        
        highScoreText.text = "Best Maze Reached "+PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeHighScore();
    }

    void ChangeHighScore()
    {
        if (levelScript.level > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore",levelScript.level);
            highScoreText.text = "Best Maze Reached "+levelScript.level.ToString();
        }
    }
}
