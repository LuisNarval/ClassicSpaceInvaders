using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void GoToMainMenu()
    {
        LoadMainScene();
    }

    public void RepeatLevel()
    {
        LoadGameScene();
    }

    public void StartGame(int indexLevel)
    {
        GameManager.currentLevel = indexLevel;
        LoadGameScene();
    }

    public void NextLevel()
    {
        GameManager.currentLevel++;
        LoadGameScene();
    }

    public static void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public static void LoadGameScene()
    {
        SceneManager.LoadScene(2);
    }
}
