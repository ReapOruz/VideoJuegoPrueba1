using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class move : MonoBehaviour
{
    public Animator anim;
    public bool flag;
    private float movX;
    private float movY;
    private bool jump;
    private Rigidbody2D rb;
    public float forceMultiplayer, jumpMultiplayer;
    Vector2 forceVector;


    // Start is called before the first frame update
    void Start()
    {
        flag = true;
        rb = GetComponent<Rigidbody2D>();
        forceMultiplayer = 8f;
        jumpMultiplayer = 11f;
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");
        jump = Input.GetButtonDown("Jump");

        anim.SetFloat("Speed_x", Mathf.Abs(movX));

        if (movX < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (movX > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (movX == 0)
        {
            forceVector = new Vector2(0f, 0f);
            rb.AddForce(forceVector);
        }


        if (flag)
        {
            moving();
        }

        if (jump)
        {
            rb.AddForce(Vector2.up * jumpMultiplayer, ForceMode2D.Impulse);
        }

        Debug.Log(forceVector);
    }

    public void moving()
    {
        forceVector = new Vector2(movX, 0f) * forceMultiplayer;
        rb.AddForce(forceVector);
    }
}
