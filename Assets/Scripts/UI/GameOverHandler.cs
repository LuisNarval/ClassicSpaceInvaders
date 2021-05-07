using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public Canvas panelWin;
    public Canvas panelLose;

    private void OnEnable()
    {
        EventManager.StartListening("GameOver", OnGameOver);
    }

    private void OnDisable()
    {
        EventManager.StopListening("GameOver", OnGameOver);
    }

    private void OnGameOver(object arg)
    {
        if ((bool)arg)
            panelWin.enabled = true;
        else
            panelLose.enabled = true;
    }
}
