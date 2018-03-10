using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {

    private GameState _gameState;

    private void Start()
    {
        _gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            _gameState.AddOre(1);
            Destroy(gameObject);
        }
    }
    


}
