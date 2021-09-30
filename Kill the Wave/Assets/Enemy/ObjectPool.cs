using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int poolSize = 5;
    [SerializeField] [Range(2f, 5f)] float spawnTimer = 4f;


    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine(spawnTimer));

    }

   

    IEnumerator EnemySpawnRoutine(float spawnSeconds)
    {
        while (poolSize > 0)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnSeconds);
        }
        
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy==false)
            {
                pool[i].SetActive(true);

                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
