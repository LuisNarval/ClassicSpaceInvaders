using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    
    public EnumEnemyType enemyType;

    public float speed;

    private void Start()
    {
        Healt = (int) enemyType;
        speed = EnemiesLayouts.levelSpeed;
    }

    public override void Move()
    {
        this.transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public override void Death()
    {
        EventManager.TriggerEvent("EnemyKilled", enemyType);
        this.gameObject.SetActive(false);
    }
}

public enum EnumEnemyType
{
    Green,
    Blue,
    Red
}
