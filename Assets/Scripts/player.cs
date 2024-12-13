using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float playerSpeed;
    public float jumpForce;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.position += new Vector2(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
    
}
