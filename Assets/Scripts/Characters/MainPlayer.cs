using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Character
{
    [Range(0f,20f)]
    public float rangeMovement = 5f;
    [Range(0f, 20f)]
    public float m_speed = 2f;
    private float moveInput;
    private Vector3 startingPos;

    private void OnEnable()
    {
        EventManager.StartListening("InputMovement", OnInputMovementDetected);
    }

    private void OnDisable()
    {
        EventManager.StopListening("InputMovement", OnInputMovementDetected);
    }

    private void Start()
    {
        moveInput = 0f;
        startingPos = this.transform.position;
    }

    public void SetInputAmount(float amount)
    {
        moveInput = amount;
    }

    public override void Move()
    {
        
        this.transform.position += Vector3.right * moveInput * Time.deltaTime * m_speed;
        this.transform.localPosition = Vector3.ClampMagnitude(this.transform.localPosition, rangeMovement);

    }

    public override void Death()
    {
    }

    private void OnInputMovementDetected(object arg)
    {
        SetInputAmount((float)arg);
    }
}
