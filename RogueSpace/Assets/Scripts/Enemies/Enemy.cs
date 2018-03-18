using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private GameObject deathEffect;

    public int health;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    
    public void Damage(int amount)
    {
        health -= amount;        
    }

    private void Die()
    {
        Destroy(Instantiate(deathEffect, transform.position, transform.rotation),3);        
        Destroy(gameObject);
    }
}
