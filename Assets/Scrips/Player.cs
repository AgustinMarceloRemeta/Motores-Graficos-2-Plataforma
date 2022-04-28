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
    GameManager Manager;
    int addition = 1;
    [SerializeField] float time= 0;
    
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }


    void Update()
    {

        movement();

        Timer();
    }

    private void Timer()
    {
        time -= Time.deltaTime;
        if (time > 0)
        {
            addition = 2;
            Manager.x2Text.gameObject.SetActive(true);
        }
        else if (time <= 0)
        {
            addition = 1;
            Manager.x2Text.gameObject.SetActive(false);
        }
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
        if (collision.gameObject.CompareTag("End")) print("Next Level");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Camera")) Cam.Cam = true;

        if (collision.gameObject.CompareTag("NoCamera")) Cam.Cam = false;

        if (collision.gameObject.CompareTag("Money")) {
            Destroy(collision.gameObject);
            Manager.Score += addition ; }

        if (collision.gameObject.CompareTag("X2")) {
            Destroy(collision.gameObject);
            time = 10;
        }
        
    }
    private void Dead()
    {
        SceneManager.LoadScene(0);
    }
}
