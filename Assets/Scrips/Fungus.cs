using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fungus : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        rb.AddForce(new Vector2(-velocity, 0), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit")) Destroy(gameObject);       
    }

}
