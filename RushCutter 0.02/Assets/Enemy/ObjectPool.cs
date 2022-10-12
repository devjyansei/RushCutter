using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0.1f,30f)] float spawnTimer = 1f;
    [SerializeField] [Range(0,50)] int poolSize;
    GameObject[] objectPool;
    private void Awake()
    {
        FillObjectPool();

    }
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    void FillObjectPool()
    {
        objectPool = new GameObject[poolSize];
        for (int i = 0; i < objectPool.Length; i++)
        {
            objectPool[i] = Instantiate(enemyPrefab, transform);
            objectPool[i].SetActive(false);
        }
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {

           EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }

    }

    private void EnableObjectInPool()
    {

        for (int i = 0; i < objectPool.Length; i++)
        {
            if (objectPool[i].activeInHierarchy == false)
            {
                objectPool[i].SetActive(true);
                return;
            }
        }    
        
        
        
    }
}
