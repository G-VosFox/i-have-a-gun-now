using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class enemyMovement : MonoBehaviour
{
    public Vector3 target;
    public Vector3 current;
    public GameObject player;
    private bool spotted = false;
    private bool coolDown = false;
    public float speed = 10f;
    public playerMovement playerScript;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
        playerScript = GameObject.FindObjectOfType(typeof(playerMovement)) as playerMovement;
    }
    // Update is called once per frame
    void Update()
    {
        current = gameObject.transform.position;
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist <= 10)
        {
            target = player.transform.position;
            spotted = true;
        }
        else if (dist > 10 && spotted == true)
        {
            target = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
            spotted = false;
        }
        
        if (dist <= 2 && coolDown == false)
        {
            coolDown = true;
            dontSpam();
            coolDown = false;
        }

        if (current == target)
        {
            target = new Vector3(Random.Range(-50f, 50f), 1.5f, Random.Range(-50f, 50f));
        }
    }
    IEnumerator dontSpam()
    {
        yield return new WaitForSeconds(1f);
        playerScript.hP -= 1;
    }
}
