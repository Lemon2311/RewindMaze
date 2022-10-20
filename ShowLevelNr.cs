using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLevelNr : MonoBehaviour
{
    private KeepTrackOfLevel levelNr;
    public TextMeshProUGUI levelText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject levelNrObject = GameObject.FindGameObjectWithTag("levelCount");
        levelNr = levelNrObject.GetComponent<KeepTrackOfLevel>();
    }
    

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Maze Reached " + levelNr.level;
    }
}
