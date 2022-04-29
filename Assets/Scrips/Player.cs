using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float velocity, jump;
    bool Touch = true, Key = false;
    Camera Cam;
    GameManager Manager;
    int addition = 1;
    [SerializeField] float time= 0;
    [SerializeField] GameObject SoundMoney, SoundPowerUp, SoundDeadEnemy;
    
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
       if( collision.gameObject.layer == LayerMask.NameToLayer("Terrain")) Touch= true;
       if( collision.gameObject.CompareTag("Enemy")) Dead();
        if (collision.gameObject.CompareTag("DeadEnemy")) 
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Dead();
            Instantiate(SoundDeadEnemy);
        }
        if (collision.gameObject.CompareTag("End")) NextLevel();
    }

    private static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Camera")) Cam.Cam = true;

        if (collision.gameObject.CompareTag("NoCamera")) Cam.Cam = false;

        if (collision.gameObject.CompareTag("Money")) {
            Destroy(collision.gameObject);
            Manager.Score += addition ;
            Instantiate(SoundMoney);
        }

        if (collision.gameObject.CompareTag("X2")) {
            Destroy(collision.gameObject);
            time = 10;
            Instantiate(SoundPowerUp);
        }
        if (collision.gameObject.CompareTag("Key")) 
        {
            collision.transform.position = new Vector3 (transform.position.x + 0.5f , transform.position.y, transform.position.z);
            collision.transform.SetParent(transform);
            Key = true;
        }
        if (collision.gameObject.CompareTag("Door")&& Key) { NextLevel(); }

    }
    private void Dead()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
