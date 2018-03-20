using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    private static GameState INSTANCE;    

    public Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

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

//        AddResource(ResourceType.EXOTIC_INGOT, 42);
//        AddResource(ResourceType.IRON_ORE, 40);
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
