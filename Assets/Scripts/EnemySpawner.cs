using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 0;
    public bool gimmeABreak = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < 15 && gimmeABreak == false)
        {
            gimmeABreak = true;
            enemyCount++;
            StartCoroutine(anotherOne());
        }
    }
    IEnumerator anotherOne()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(enemyPrefab, new Vector3(Random.Range(-50f, 50f), transform.position.y, 49), Quaternion.identity);
        gimmeABreak = false;
    }
}
