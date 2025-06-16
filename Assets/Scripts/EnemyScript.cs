using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Sprite[] enemyVaritants;

    [SerializeField] float enemySpeed;
    [SerializeField] float lifeTime;

    [SerializeField] GameObject hiteffect;
    [SerializeField] AudioClip audioOnHit;

    PlayerScript playerScript;
    SceneLoader sceneLoader;
    EnemySpawner enemySpawner;
    SoundEffectPlayer soundEffects;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    int randomVariant;
    
    Vector2 position;

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        soundEffects = FindObjectOfType<SoundEffectPlayer>();

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.rotation = Random.Range(0, 360);
        randomVariant = Random.Range(0, enemyVaritants.Length);

        spriteRenderer.sprite = enemyVaritants[randomVariant];

        StartCoroutine(DestroyAfterTime());
    }

    private void FixedUpdate()
    {
        rb.velocity = (transform.up).normalized * enemySpeed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.EnemyHit();
            sceneLoader.ChangeScene(2);
        }
        enemySpawner.IfDestroyed();
        Destroy(gameObject);

        if (position.x > -3 && position.x < 19 && position.y > 0 && position.y < 12) //om enemy befinner sig inanför skärmen.
        {
            soundEffects.EnemyHit();
            Instantiate(hiteffect, transform.position, Quaternion.identity);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifeTime); //Startar funktion efter antal sekunder
        enemySpawner.IfDestroyed();
        Destroy(gameObject);
    }
}
