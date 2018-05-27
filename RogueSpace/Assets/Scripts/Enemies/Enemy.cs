using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable {

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int lootAmount;

    [SerializeField]
    private List<InventoryItem> specialLoot;

    [SerializeField]
    private GameObject deathEffect;

    private LevelManager levelManager;

    [HideInInspector]
    public int health;

    private void Start()
    {
        levelManager = LevelManager.Find();
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
        SpawnLoot();
        GameSound.Play(deathSound);
        Destroy(Instantiate(deathEffect, transform.position, transform.rotation),3);        
        Destroy(gameObject);
    }

    private void SpawnLoot()
    {
        for (int i = 0; i < lootAmount; i++)
        {
            GameObject loot = Instantiate(levelManager.RandomLoot(), transform.position, transform.rotation);
            loot.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 200);
        }

        foreach (InventoryItem loot in specialLoot)
        {
            levelManager.CratedLoot(loot, transform.position, transform.rotation);
        }

    }
}
