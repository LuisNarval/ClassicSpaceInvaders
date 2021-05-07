using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{

    public float timeToWait = 3f;
    private WaitForSeconds m_waitForSeconds;
    
    void Start()
    {
        m_waitForSeconds = new WaitForSeconds(timeToWait);
        StartCoroutine(RoutineLoadScene());
        Application.targetFrameRate = 60;
    }

    IEnumerator RoutineLoadScene()
    {
        yield return m_waitForSeconds;
        LevelLoader.LoadMainScene();
    }
}
