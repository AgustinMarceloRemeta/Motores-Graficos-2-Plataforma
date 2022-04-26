using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float negative, positive;
    void Start()
    {
        positive = transform.position.x + 3;
        negative = transform.position.x - 3;
    }


    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) print("Muere Enemy");
    }
}
