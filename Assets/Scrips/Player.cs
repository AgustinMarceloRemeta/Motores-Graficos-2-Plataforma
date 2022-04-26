using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity, jump;
    bool Touch = true;
    Camera Cam;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    void Update()
    {
        if (Input.GetKey("d")) rb.AddForce(new Vector2(velocity, 0), ForceMode2D.Force);
        if (Input.GetKey("a")) rb.AddForce(new Vector2(-velocity, 0), ForceMode2D.Force);
        if (Input.GetKey("w")&& Touch) { 
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            Touch = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if( collision.gameObject.CompareTag("terrain")) Touch= true;
       if( collision.gameObject.CompareTag("Enemy")) print("muere");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Camera")) Cam.Cam = true;
        if (collision.gameObject.CompareTag("NoCamera")) Cam.Cam = false;
    }
}
