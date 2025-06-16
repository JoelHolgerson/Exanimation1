using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    [SerializeField] AudioClip enemyHit;
    [SerializeField] AudioClip scoreHit;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EnemyHit()
    {
        audioSource.clip = enemyHit;
        audioSource.Play();
    }

    public void ScoreHit()
    {
        audioSource.clip = scoreHit;
        audioSource.Play();
    }
}
