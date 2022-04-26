using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public bool Cam;
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if(Cam) transform.position = new Vector3 (Player.transform.position.x,0,transform.position.z);
    }
}
