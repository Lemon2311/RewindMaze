using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnableDisableAgent : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public timeBody timeBody;
    [FormerlySerializedAs("level")] public KeepTrackOfLevel levelS;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timeBody = GetComponent<timeBody>();
        levelS = GameObject.FindWithTag("levelCount").GetComponent<KeepTrackOfLevel>();
        
        GrowSpeedWithGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Player") == null)
            agent.enabled = false;
        else
          if (timeBody.isRewinding)
        {
            agent.enabled = false;
        }
        else
            agent.enabled = true;
    }

    void GrowSpeedWithGame()
    {
        agent.speed += levelS.level/2f;

        if (agent.speed > 15)
            agent.speed = 15;
        
        if (levelS.level > 30)
            agent.speed = 16;

        if (levelS.level > 35)
            agent.speed = 17;
    }
}