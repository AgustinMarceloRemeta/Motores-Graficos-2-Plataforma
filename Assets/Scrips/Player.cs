using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    Rigidbody2D rb;
    public float velocity, jump;
    bool Touch = true;
    Camera Cam;
   
    
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    void Update()
    {
        movement();
    }

    private void movement()
    {
        if (Input.GetKey("d")) transform.Translate(velocity, 0, 0);
        if (Input.GetKey("a")) transform.Translate(-velocity, 0, 0);
        if ((Input.GetKeyDown("w")|| Input.GetKeyDown(KeyCode.Space)) && Touch)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            Touch = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if( collision.gameObject.CompareTag("terrain")) Touch= true;
       if( collision.gameObject.CompareTag("Enemy")) Dead();
        if (collision.gameObject.CompareTag("DeadEnemy")) 
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Dead(); 
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Camera")) Cam.Cam = true;
        if (collision.gameObject.CompareTag("NoCamera")) Cam.Cam = false;
    }
    private void Dead()
    {
        SceneManager.LoadScene(0);
    }
}
