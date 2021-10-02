using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints;
    int deathCount;

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
        
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        deathCount = 0;
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
        deathCount++;

        maxHitPoints += difficultyRamp + deathCount;
        
        enemy.RewardGold();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
