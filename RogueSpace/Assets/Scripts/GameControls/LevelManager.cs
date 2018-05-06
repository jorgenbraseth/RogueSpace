using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public Player player;

    [SerializeField]
    private ModalWindow youWin;

    [SerializeField]
    private ModalWindow youLoose;

   
    [SerializeField]
    private LootChance[] lootTable;

    [SerializeField]
    private GameObject exit;

    [SerializeField]
    private LootCrate lootCratePrefab;

    [SerializeField]
    private ObjectivePointers pointers;


    GameState gameState;

    private void Awake()
    {
        Time.timeScale = 1;
        gameState = GameObject.Find("GameState").GetComponent<GameState>();

        //exit.SetActive(false);

        InitPointers(); //TODO: add pointers through level manager     

    }    

    private void InitPointers()
    {
        pointers.AddExit(exit.GetComponent<MapExit>());

    }

    public GameObject RandomLoot()
    {
        float sumOfChances = 0f;
        foreach(LootChance loot in lootTable) {
            sumOfChances += loot.chance;               
        }

        float picked = UnityEngine.Random.Range(0f, sumOfChances);
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

    public LootCrate CratedLoot(InventoryItem loot, Vector3 position, Quaternion rotation)
    {
        lootCratePrefab.SetLoot(loot);
        return Instantiate(lootCratePrefab, position, rotation);        
    }

    private void EndLevel()
    {
        SceneManager.LoadScene("Home");        
    }

    public void ObjectiveComplete()
    {
        exit.SetActive(true);
    }

    public void LevelComplete()
    {        
        foreach(InventoryItem loot in player.lootedItems)
        {
            gameState.AddLoot(loot);           
        }
        youWin.Open(EndLevel);
    }

    public void Died()
    {
        youLoose.Open(EndLevel);        
    }

    public static LevelManager Find()
    {
        return GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

}
