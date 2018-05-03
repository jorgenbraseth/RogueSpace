using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    private GameState gameState;

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private LevelManager level;

    [SerializeField]
    private GameObject mainGunMountPoint;

    public int health;

    public int ore;
    private Gun mainGun;

    void Start () {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();

        ore = 0;
        health = maxHealth;

        ConfigureShip();
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
    	
    private void ConfigureShip()
    {
        mainGun = Instantiate(gameState.shipConfig.mainWeapon, mainGunMountPoint.transform);
    }

    public void Shoot(Vector3 aim)
    {
        mainGun.Shoot(aim);
    }

    public List<InventoryItem> lootedItems = new List<InventoryItem>();
    public bool AddLoot(InventoryItem loot)
    {
        lootedItems.Add(loot);
        return true;
    }
}
