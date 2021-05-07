using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [Header("Respawn properties")]
    public float timeToDisable = 10;

    private void OnEnable()
    {
        EnableObject();
    }

    public virtual void EnableObject()
    {
        StartCoroutine(RoutineDisableObject());
    }

    public virtual void DisableThisObject()
    {
        this.gameObject.SetActive(false);
    }

    IEnumerator RoutineDisableObject()
    {
        yield return new WaitForSeconds(timeToDisable);
        DisableThisObject();
    }

}
