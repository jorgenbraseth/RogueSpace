using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    private static GameState INSTANCE;

    [SerializeField]
    private int oreAmount = 0;

    private void Start()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void AddOre(int amount)
    {
        oreAmount += amount;
    }

    public int OreAmount()
    {
        return oreAmount;
    }
	
}
