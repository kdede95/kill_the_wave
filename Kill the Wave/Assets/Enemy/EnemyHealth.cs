using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints;

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints<1)
        {
            StartDeathSequence();  
        }
    }
    void StartDeathSequence()
    {
        gameObject.SetActive(false);
        enemy.RewardGold();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
