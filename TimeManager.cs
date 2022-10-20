
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.5f;

    public float slowdownLength = 2f;

    public /*static*/ void DoSlowMotion(/*float slowdownFactor*/)
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }


}
