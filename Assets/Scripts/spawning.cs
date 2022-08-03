using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemyPrefab;
    private float enemyCount;
    public float spawnCD;
    private float timeCount;

    private void Start()
    {
        enemyCount = 0;
        timeCount = 0;
    }
    public void Update()
    {
       if(enemyCount < 30 && timeCount >= spawnCD)
        {
           int randI =  Random.Range(0, spawners.Length - 1);
            GameObject.Instantiate(enemyPrefab, spawners[randI].transform.position, enemyPrefab.transform.rotation);
            ++enemyCount;
            timeCount = 0;
        }
        timeCount += Time.deltaTime;
    }
}
