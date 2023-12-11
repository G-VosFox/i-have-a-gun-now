using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class enemyMovement : MonoBehaviour
{
    public Vector3 target;
    public Vector3 current;
    public Vector3 range;
    public GameObject player;
    private bool spotted = false;
    public float speed = 5f;
    public playerMovement playerScript;
    public int areaMask;
    public NavMeshAgent enemy;
    // Start is called before the first frame update
    void Start()
    {
        range = new Vector3(2f, 2f, 2f);
        target = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
        playerScript = GameObject.FindObjectOfType(typeof(playerMovement)) as playerMovement;
        player = playerScript.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        current = gameObject.transform.position;
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(current, target, areaMask, navMeshPath);
        enemy.SetDestination(target);

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (current == Vector3.zero)
        {
            target = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
        }

        if (dist <= 10)
        {
            target = player.transform.position;
            spotted = true;
            speed = 10f;
        }
        else if (dist > 10 && spotted == true)
        {
            target = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
            spotted = false;
            speed = 5f;
        }
        

        if (current == target + range || current == target - range)
        {
            target = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
        }
    }
}
