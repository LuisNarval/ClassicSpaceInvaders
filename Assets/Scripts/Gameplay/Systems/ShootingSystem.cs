using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public PoolManager bulletPool;
    [Range(0.01f,5f)]
    public float shootRate = 1f;

    private float m_timeSinceShooting;
    private bool m_isShooting;

    void Update()
    {
        if (m_isShooting)
        {
            m_timeSinceShooting += Time.deltaTime;
            if (m_timeSinceShooting > shootRate)
                m_isShooting = false;

            return;
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Shoot();
        }
        
    }

    public void Shoot()
    {
        if (m_isShooting)
            return;

        m_timeSinceShooting = 0;
        m_isShooting = true;
        bulletPool.AskForObject(this.transform.position);
        EventManager.TriggerEvent("PlayerShooted", null);
    }

    
}
