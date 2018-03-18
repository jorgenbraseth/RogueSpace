using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private LevelManager level;

    public int health;

    public int ore;

    // Use this for initialization
    void Start () {
        ore = 0;
        health = maxHealth;		
	}

    public void damage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        level.Died();
    }
	

    public bool AddOre(int amount)
    {
        ore += amount;
        return true;
    }
	
}
