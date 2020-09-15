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


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        forceMultiplayer = 4f;
        jumpMultiplayer = 7f;

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
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //transform.position += new Vector3(movX, 0f, 0f) * Time.deltaTime * 4;

        /*Vector2 forceVector = new Vector2(movX, 0f) * forceMultiplayer;
        rb.AddForce(forceVector);*/

        if (flag)
        {
            Vector2 forceVector = new Vector2(movX, 0f) * forceMultiplayer;
            rb.AddForce(forceVector);

        }
        else
        {
            Vector2 forceVector = new Vector2(movX, 0f);
            rb.velocity = forceVector;

        }

        if (jump)
            rb.AddForce(Vector2.up * jumpMultiplayer, ForceMode2D.Impulse);


        Debug.Log(movY);

    }
}
