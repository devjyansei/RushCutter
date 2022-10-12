using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int difficultyRamp = 1;
    int currrentHealth;
    Enemy enemy;
    
    void OnEnable()
    {
        currrentHealth = maxHealth;
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
        currrentHealth--;

        if (currrentHealth <= 0)
        {
            maxHealth += difficultyRamp;
            gameObject.SetActive(false);
            enemy.GainGold();

        }
    }

}
