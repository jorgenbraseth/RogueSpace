using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField]
    private int maxHealth;

    public int health;
   // public int health { get; }

    // Use this for initialization
    void Start () {        
        health = maxHealth;
		
	}

    public void damage(int amount)
    {
        health -= amount;
    }
	
	
}
