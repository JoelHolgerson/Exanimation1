using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;

    ScoreManager scoreManager;
    ScoreSpawner scoreSpawner;
    SoundEffectPlayer soundEffects;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreSpawner = FindObjectOfType<ScoreSpawner>();
        soundEffects = FindObjectOfType<SoundEffectPlayer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreManager.ScoreAdd();

            Instantiate(hitEffect, transform.position, Quaternion.identity);
            soundEffects.ScoreHit();
        }
        scoreSpawner.RemovedScore();
        Destroy(gameObject);
    }
}
