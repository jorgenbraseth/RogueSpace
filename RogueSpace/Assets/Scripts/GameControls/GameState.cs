using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameState : MonoBehaviour {

    private static GameState INSTANCE;

    [SerializeField]
    private List<ResourceInventoryItem> startingResources = new List<ResourceInventoryItem>();

    public List<ResourceInventoryItem> resources = new List<ResourceInventoryItem>();

    public List<InventoryItem> items = new List<InventoryItem>();

    [SerializeField]
    private Gun _defaultGun;

    public ShipConfig shipConfig = new ShipConfig();

    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            AddStartInventory();            
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);    
              
    }

    private void AddStartInventory()
    {
        foreach (InventoryItem startingResource in startingResources)
        {
            AddLoot(startingResource);
        }
        startingResources.Clear();

        if (_defaultGun != null) {
            AddLoot(_defaultGun);
            _defaultGun = null;
            shipConfig.mainWeapon = (Gun)items[0];
        }
    }

    private void AddResource(ResourceInventoryItem loot)
    {
        bool found = false;
        foreach (ResourceInventoryItem res in resources)
        {
            if (res.resourceType == loot.resourceType)
            {
                res.count += loot.count;
                found = true;
                Destroy(loot);
            }
        }

        if(!found)
        {
            DontDestroyOnLoad(loot);
            resources.Add(loot);
        }
    }
    private void RemoveResource(ResourceInventoryItem loot)
    {
        List<ResourceInventoryItem> toRemove = new List<ResourceInventoryItem>();
        foreach (ResourceInventoryItem res in resources)
        {
            if (res.resourceType == loot.resourceType)
            {
                res.count -= loot.count;
            }
            if (res.count <= 0)
            {
                toRemove.Add(res);   
            }
                
        }

        foreach (ResourceInventoryItem res in toRemove)
        {
            resources.Remove(res);
        }
    }
    public void RemoveLoot(InventoryItem loot)
    {
        if (loot.IsResource())
        {
            RemoveResource((ResourceInventoryItem)loot);
        }
        else
        {
            items.Remove(loot);
        }
    }

    public void AddLoot(InventoryItem lootToAdd)
    {
        InventoryItem loot = Instantiate(lootToAdd);        
        if (loot.IsResource())
        {
            AddResource((ResourceInventoryItem)loot);
        }
        else
        {
            DontDestroyOnLoad(loot);
            items.Add(loot);
        }        
    }

    public static GameState Find()
    {
        return GameObject.Find("GameState").GetComponent<GameState>();
    }
    
	
}

[Serializable]
public class ShipConfig
{
    public Gun mainWeapon;
}
