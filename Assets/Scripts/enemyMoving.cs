using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoving : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 0;

    [SerializeField]

    float timeLimit = 0;

    float timer = 0;

    Vector2 dir = Vector2.right;

    SpriteRenderer spr;

    void Awake() {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            timer = 0;
            spr.flipX = flipSprite;
            dir.x = dir.x > 0 ? -1 : 1;  
        }
    }

    bool flipSprite
    {
        get => dir.x > 0 ? true : false;
    }

}
