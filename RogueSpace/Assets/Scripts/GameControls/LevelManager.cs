using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private Player player;

    GameState gameState;

    private void Awake()
    {
        gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }


    private void EndLevel()
    {
        SceneManager.LoadScene("Home");
        Debug.Log("Level ended!");
    }

    public void LevelComplete()
    {
        gameState.AddOre(player.ore);
        EndLevel();
    }

    public void Died()
    {
        Debug.Log("YOU DIED!");
        EndLevel();
    }
}
