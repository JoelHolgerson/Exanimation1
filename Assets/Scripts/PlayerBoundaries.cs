using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    float playerWidth;
    float playerHeight;

    Vector2 screenBoundaries;
    Vector3 maxPosition;

    private void Start()
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));

        playerWidth = GetComponent<SpriteRenderer>().bounds.extents.x / 10;
        playerHeight = GetComponent<SpriteRenderer>().bounds.extents.y / 10;
    }

    private void Update()
    {
        maxPosition = transform.position;

        maxPosition.x = Mathf.Clamp(maxPosition.x, screenBoundaries.x * 0 - playerWidth, screenBoundaries.x + playerHeight);
        maxPosition.y = Mathf.Clamp(maxPosition.y, screenBoundaries.y * 0 - playerHeight, screenBoundaries.y + playerWidth);

        transform.position = maxPosition;
    }
}
