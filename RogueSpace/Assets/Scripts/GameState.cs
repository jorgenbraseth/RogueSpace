using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    [SerializeField]
    private int oreAmount;

    public void AddOre(int amount)
    {
        oreAmount += amount;
    }

    public int OreAmount()
    {
        return oreAmount;
    }
	
}
