using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currentLevel;

    public bool isGameOver;

    [SerializeField]
    private int enemiesInScene = 0;

    private void Start()
    {
        isGameOver = false;
    }

    private void OnEnable()
    {
        EventManager.StartListening("EnemyKilled", OnEnemyKilled);
        EventManager.StartListening("EnemyCreated", OnEnemyCreated);

    }

    private void OnDisable()
    {
        EventManager.StopListening("EnemyKilled", OnEnemyKilled);
        EventManager.StopListening("EnemyCreated", OnEnemyCreated);
    }


    private void OnEnemyCreated(object arg)
    {
        enemiesInScene++;
    }

    private void OnEnemyKilled(object arg)
    {
        if (isGameOver)
            return;

        enemiesInScene--;
        if (enemiesInScene <= 0)
        {
            EventManager.TriggerEvent("GameOver", true);
            isGameOver = true;
        }
            
    }

    public void EnemyReachedPlayer()
    {

        if (isGameOver)
            return;

        isGameOver = true;
        EventManager.TriggerEvent("GameOver", false);
        
    }

}
