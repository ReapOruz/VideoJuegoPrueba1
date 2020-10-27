using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 2f;

    [SerializeField]
    float timeLimit = 2f;

    float timer = 0f;

    Vector2 dir = Vector2.right;

    public float radioVision = 10f;
    public float speed = 4f;

    GameObject player;

    Vector3 posicioninicial;

    SpriteRenderer spr;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        posicioninicial = transform.position;
    }

    void Update()
    {
        perseguir();

    }

    public void perseguir()
    {
        Vector3 objetivo = posicioninicial;
        float distancia = Vector3.Distance(player.transform.position, transform.position);
        if (distancia < radioVision)
        {
            objetivo = player.transform.position;
            spr.flipX = false;
        }
        else
        {
            patrullar();
        }

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, objetivo, fixedSpeed);

    }
    void patrullar()
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            timer = 0f;
            spr.flipX = flipSprite;
            dir.x = dir.x > 0 ? -1 : 1;
        }
    }

    bool flipSprite
    {
        get => dir.x > 0 ? true : false;
    }

}
