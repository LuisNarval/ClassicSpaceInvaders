using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemySystem : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.EnemyReachedPlayer();
    }
}
