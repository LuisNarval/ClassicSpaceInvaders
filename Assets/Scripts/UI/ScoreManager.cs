using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int totalScore;
    public Text textScore;

    private void Start()
    {
        totalScore = 0;
        SetScoreOnText();
    }

    private void OnEnable()
    {
        EventManager.StartListening("EnemyKilled", OnEnemyKilled);
    }

    private void OnDisable()
    {
        EventManager.StopListening("EnemyKilled", OnEnemyKilled);
    }


    public void SetScoreOnText()
    {
        textScore.text = totalScore.ToString();
    }

    private void OnEnemyKilled(object arg)
    {
        totalScore += (int) ((EnumEnemyType)arg) + 1;
        SetScoreOnText();
    }
}
