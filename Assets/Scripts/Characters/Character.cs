using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamagable
{
    private int m_health;
    public int Healt { get { return m_health; } set { m_health = value; } }

    private void Update()
    {
        Move();
    }

    public void ReceiveDamage(int amount)
    {
        m_health-=amount;
        if (m_health < 0)
            Death();
    }

    public abstract void Death();

    public abstract void Move();


}
