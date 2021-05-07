using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObject : PoolObject
{
    public int damageBullet;
    [Range(0f,20f)]
    public float speed = 2f;

    private Rigidbody2D m_rb;

    private void Awake()
    {
        m_rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamagable>().ReceiveDamage(damageBullet);
        DisableThisObject();
    }

    public override void EnableObject()
    {
        base.EnableObject();
        m_rb.velocity = Vector2.up * speed;
    }
}
