using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLayouts : MonoBehaviour
{
    public static float levelSpeed;

    [Header("Layout settings")]
    public PoolManager[] poolEnemies;
    public string[] rows;

    [Header("Layout Parameteres in Scene")]
    public Transform startingLayoutPoint;
    public float columnSize = 1f;
    public float rowSize = 1f;


    private int indexEnemy;
    private Vector3 m_positionInScene;

    private void Start()
    {
        if (GameManager.currentLevel <= 0)
            GameManager.currentLevel = 1;
        LoadLayout(GameManager.currentLevel);
    }

    public void LoadLayout(int index)
    {
        var layoutFromTextAsset = (TextAsset) Resources.Load("LevelLayouts/" + index.ToString());
        
        rows = layoutFromTextAsset.text.Split('\n');

        m_positionInScene = startingLayoutPoint.position;

        levelSpeed = float.Parse(rows[0]);

        for (int i = 1; i < rows.Length;i++)
        {
            for (int j = 0; j < rows[i].Length;j++)
            {
                indexEnemy = (int) char.GetNumericValue(rows[i][j]);
                if (indexEnemy>0)
                {
                    EventManager.TriggerEvent("EnemyCreated", null);
                    poolEnemies[indexEnemy - 1].AskForObject(m_positionInScene);
                }
                    
                
                m_positionInScene.x += columnSize;
            }

            m_positionInScene.x = startingLayoutPoint.position.x;
            m_positionInScene.y -= rowSize;
        }
    }

}


