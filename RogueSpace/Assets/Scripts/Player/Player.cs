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

    [SerializeField]
    private Gun mainGun;

    void Awake () {
        gameState = GameState.Find();
        

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
    	
    public void ConfigureShip(ShipConfig shipConfig, GameState gs)
    {
        mainGun = (Gun)gs.itemLibrary.Create(shipConfig.mainWeapon.itemLibraryKey);
        mainGun.transform.SetParent(mainGunMountPoint.transform);
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
