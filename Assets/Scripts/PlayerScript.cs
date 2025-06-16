using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;

    Rigidbody2D rb;

    Vector3 mousePos;
    Vector2 playerPos;

    private void Start()
    {
        gameObject.tag = "Player";
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        playerPos = Vector2.Lerp(transform.position, mousePos, moveSpeed);

        TurnWithMouse();
    }

    void TurnWithMouse()
    {
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = direction;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(playerPos);
    }

    public void EnemyHit()
    {
        Destroy(gameObject);
    }
}