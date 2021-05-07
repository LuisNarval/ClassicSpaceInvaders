using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    public Animator animator;

    private void OnEnable()
    {
        EventManager.StartListening("PlayerShooted", OnShootPlayer);
        EventManager.StartListening("InputMovement", OnInputPlayer);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PlayerShooted", OnShootPlayer);
        EventManager.StopListening("InputMovement", OnInputPlayer);
    }

    private void OnShootPlayer(object arg)
    {
        animator.SetTrigger("Attack");
    }

    private void OnInputPlayer(object arg)
    {
        animator.SetBool("Walk",Mathf.Abs((float)arg) > 0);
    }
}
