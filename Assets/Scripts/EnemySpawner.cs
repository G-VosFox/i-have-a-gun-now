using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, new Vector3(49, 1, 49), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(49, 1, 49), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(49, 1, 49), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(49, 1, 49), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(49, 1, 49), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        anotherOne();
    }
    IEnumerator anotherOne()
    {
        Instantiate(enemyPrefab, new Vector3(49, 1, 49), Quaternion.identity);
        yield return new WaitForSeconds(10f);
    }
}
