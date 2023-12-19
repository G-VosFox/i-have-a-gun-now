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
    public playerMovement playerScript;
    public GameObject player;
    private bool spotted = false;
    public int areaMask;
    public NavMeshAgent enemy;
    public float distance;
    public shooting hit;

    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(Random.Range(-50f, 50f), transform.position.y, Random.Range(-50f, 50f));
        playerScript = GameObject.FindObjectOfType(typeof(playerMovement)) as playerMovement;
        player = playerScript.gameObject;
        hit = GameObject.FindObjectOfType<shooting>();

    }
    // Update is called once per frame
    void Update()
    {
        current = gameObject.transform.position;
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(current, target, areaMask, navMeshPath);
        enemy.SetDestination(target);

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (hit.shot)
        {
            target = -player.transform.position;
            enemy.speed = 14f;
        }
        else
        {
            target = new Vector3(Random.Range(-50f, 50f), transform.position.y, Random.Range(-50f, 50f));
            enemy.speed = 3.5f;
        }

        if (enemy.velocity == Vector3.zero)
        {
            target = new Vector3(Random.Range(-50f, 50f), transform.position.y, Random.Range(-50f, 50f));
        }

        if (dist <= 10)
        {
            target = player.transform.position;
            spotted = true;
            enemy.speed = 7f;
        }
        else if (dist > 10 && spotted == true)
        {
            target = new Vector3(Random.Range(-50f, 50f), transform.position.y, Random.Range(-50f, 50f));
            spotted = false;
            enemy.speed = 3.5f;
        }
        

        if (target.x == transform.position.x && target.z == transform.position.z) 
        {
            target = new Vector3(Random.Range(-50f, 50f), transform.position.y , Random.Range(-50f, 50f));
        }
    }
}
