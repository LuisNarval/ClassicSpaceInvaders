using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevelText : MonoBehaviour
{
    public Text textLevel;
    
    void Start()
    {
        textLevel.text = GameManager.currentLevel.ToString();
    }

}
