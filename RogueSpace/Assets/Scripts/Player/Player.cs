using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private LevelManager level;

    public int health;
   // public int health { get; }

    // Use this for initialization
    void Start () {        
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
	
	
}
