using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameState : MonoBehaviour {

    private static GameState INSTANCE;    

    public Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    public List<GameObject> items = new List<GameObject>();

    [SerializeField]
    private GameObject _defaultGun;

    public ShipConfig shipConfig = new ShipConfig();

    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


        items.Add(_defaultGun);
        shipConfig.mainWeapon = _defaultGun;

        AddResource(ResourceType.COPPER_INGOT, 5);
        

    }    

    public void AddResource(ResourceType type, int amount)
    {
        if (!resources.ContainsKey(type))
        {
            resources[type] = 0;
        }
        resources[type] += amount;
    }
    
	
}

[Serializable]
public class ShipConfig
{
    public GameObject mainWeapon;
}
