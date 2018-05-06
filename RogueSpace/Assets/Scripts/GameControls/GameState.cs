using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;


public class GameState : MonoBehaviour {

    private static GameState INSTANCE;

    [SerializeField]
    private List<ResourceInventoryItem> startingResources = new List<ResourceInventoryItem>();

    public Inventory inventory = new Inventory();
    
    [SerializeField]
    private Gun _defaultGun;

    public ShipConfig shipConfig = new ShipConfig();

    DatabaseReference firebase;

    private void Awake()
    {
        if (INSTANCE == null)
        {
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);    
              
    }

    private void SaveState()
    {
        InventoryEntries entries = new InventoryEntries();        
        foreach (InventoryItem it in inventory.resources)
        {
            entries.items.Add(InventoryEntry.From(it));
        }
        
        
        firebase.Child("users").Child("username").Child("gamestate").Child("inventory").SetRawJsonValueAsync(JsonUtility.ToJson(entries));
    }

    private void Init()
    {
        INSTANCE = this;        
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://roguespace-gamestate.firebaseio.com/");
        firebase = FirebaseDatabase.DefaultInstance.RootReference;
        AddStartInventory();
        SaveState();
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
            shipConfig.mainWeapon = (Gun)inventory.items[0];
        }
    }

    private void AddResource(ResourceInventoryItem loot)
    {
        bool found = false;
        foreach (ResourceInventoryItem res in inventory.resources)
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
            inventory.resources.Add(loot);
        }
    }
    private void RemoveResource(ResourceInventoryItem loot)
    {
        List<ResourceInventoryItem> toRemove = new List<ResourceInventoryItem>();
        foreach (ResourceInventoryItem res in inventory.resources)
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
            inventory.resources.Remove(res);
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
            inventory.items.Remove(loot);
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
            inventory.items.Add(loot);
        }
        SaveState();
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

[Serializable]
public class Inventory
{
    [SerializeField]
    public List<ResourceInventoryItem> resources = new List<ResourceInventoryItem>();
    public List<InventoryItem> items = new List<InventoryItem>();
}