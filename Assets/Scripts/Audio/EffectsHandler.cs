using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{

    public AudioClip[] clips_deathEnemy;
    public AudioClip clip_shootPlayer;

    public AudioSource audioSource;

    private void OnEnable()
    {
        EventManager.StartListening("EnemyKilled", OnEnemyDeath);
        EventManager.StartListening("PlayerShooted", OnPlayerShoot);
    }

    private void OnDisable()
    {
        EventManager.StopListening("EnemyKilled", OnEnemyDeath);
        EventManager.StopListening("PlayerShooted", OnPlayerShoot);
    }

    private void OnEnemyDeath(object arg)
    {
        audioSource.PlayOneShot(clips_deathEnemy[(int)(EnumEnemyType)arg]);
    }

    private void OnPlayerShoot(object arg)
    {
        audioSource.PlayOneShot(clip_shootPlayer);
    }
}
