using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMario : MonoBehaviour
{
    [SerializeField] GameObject fungus;
    [SerializeField] Transform Spawn;

    void Start()
    {
        InvokeRepeating("SpawnFungus", 2, 2);
    }


    void Update()
    {
        
    }
    void SpawnFungus()
    {
        Instantiate(fungus, Spawn);
    }
}
