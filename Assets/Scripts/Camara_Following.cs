using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_Following : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(5f, 2f,-10f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
