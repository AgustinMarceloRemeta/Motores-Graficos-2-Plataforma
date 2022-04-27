using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float negative, positive;
    public float velocity;
    public bool right = true;
    public GameObject body;
    void Start()
    {
        positive = transform.position.x + 3;
        negative = transform.position.x - 3;
    }


    void Update()
    {
        Movement();
        body.transform.position = new Vector3(gameObject.transform.position.x, body.transform.position.y, body.transform.position.z);
    }

    private void Movement()
    {
        if (right) transform.Translate(velocity, 0, 0);
        if (!right) transform.Translate(-velocity, 0, 0);
        if (transform.position.x > positive) right = false;
        if (transform.position.x < negative) right = true;
    }

    public void Dead() { 
        Destroy(gameObject); 
        Destroy(body); 
    }
}
