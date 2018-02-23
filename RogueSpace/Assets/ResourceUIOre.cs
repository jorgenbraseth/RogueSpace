using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUIOre : MonoBehaviour {

    private GameState _game;
    private Text _text;
	// Use this for initialization
	void Start () {
        _game = GameObject.Find("GameState").GetComponent<GameState>();
        _text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        _text.text = "Ore: " + _game.OreAmount();
	}
}
