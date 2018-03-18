using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable {

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private GameObject deathEffect;

    private LevelManager levelManager;

    public int health;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        health = maxHealth;
    }

    private void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    
    public void Damage(int amount, Vector3 pos, Vector3 dir)
    {
        health -= amount;        
    }

    private void Die()
    {        
        Instantiate(levelManager.RandomLoot(), transform.position, transform.rotation);
        
        Destroy(Instantiate(deathEffect, transform.position, transform.rotation),3);        
        Destroy(gameObject);
    }
}
