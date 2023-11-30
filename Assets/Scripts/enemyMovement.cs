using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyMovement : MonoBehaviour
{
    private Vector3 target;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        target = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
    }
}
