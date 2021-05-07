using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelSelect : MonoBehaviour
{
    public Button btn_Asociated;
    public Text textButtonLevel;
    public LevelLoader levelLoader;

    private int m_levelIndex;

    private void Awake()
    {
        if (levelLoader==null)
            levelLoader = GameObject.FindObjectOfType<LevelLoader>();
    }

    private void Start()
    {
        m_levelIndex = this.transform.GetSiblingIndex() + 1;
        textButtonLevel.text = "LVL " + m_levelIndex.ToString();
    }

    public void LoadLevelScene()
    {
        levelLoader.StartGame(m_levelIndex);
    }
}
