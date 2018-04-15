using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private Player player;

    [SerializeField]
    private ModalWindow youWin;

    [SerializeField]
    private ModalWindow youLoose;

    [SerializeField]
    private LootChance[] lootTable;

    [SerializeField]
    private GameObject exit;

    [SerializeField]
    private ObjectivePointers pointers;


    GameState gameState;

    private void Awake()
    {
        Time.timeScale = 1;
        gameState = GameObject.Find("GameState").GetComponent<GameState>();

        exit.SetActive(false);

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
    }

    public void ObjectiveComplete()
    {
        exit.SetActive(true);
    }

    public void LevelComplete()
    {
        foreach(KeyValuePair<ResourceType,int> loot in player.lootedResources) {
            gameState.AddResource(loot.Key, loot.Value);
        }
        youWin.Open(EndLevel);
    }

    public void Died()
    {
        youLoose.Open(EndLevel);        
    }
}
