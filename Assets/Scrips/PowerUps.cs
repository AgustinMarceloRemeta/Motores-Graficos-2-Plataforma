using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Sprite ChangeSprite;
    SpriteRenderer Sp;
    public GameObject Object;
    bool Change = true;
    void Start()
    {
        Sp = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (collision.gameObject.CompareTag("Player")&& Change)
        {
            Sp.sprite = ChangeSprite;
            Instantiate(Object, transform.position + new Vector3 (0,1,0),Quaternion.identity);
            Change = false;
        }
    }
}
