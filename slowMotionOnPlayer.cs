
using UnityEngine;



public class slowMotionOnPlayer : MonoBehaviour
{
    public TimeManager timeManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
           timeManager.DoSlowMotion();

            
    }
}
