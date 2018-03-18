using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private Player player;

    [SerializeField]
    private LootChance[] lootTable;

    GameState gameState;

    private void Awake()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public GameObject RandomLoot()
    {
        float sumOfChances = 0f;
        foreach(LootChance loot in lootTable) {
            sumOfChances += loot.chance;               
        }

        float picked = Random.Range(0f, sumOfChances);
        foreach (LootChance loot in lootTable)
        {
            picked -= loot.chance;
            if (picked <= 0)
            {
                return loot.loot;
            }
        }

        return null;
    }

    private void EndLevel()
    {
        SceneManager.LoadScene("Home");
        Debug.Log("Level ended!");
    }

    public void LevelComplete()
    {
        foreach(KeyValuePair<ResourceType,int> loot in player.lootedResources) {
            gameState.AddResource(loot.Key, loot.Value);
        }
        EndLevel();
    }

    public void Died()
    {
        Debug.Log("YOU DIED!");
        EndLevel();
    }
}
