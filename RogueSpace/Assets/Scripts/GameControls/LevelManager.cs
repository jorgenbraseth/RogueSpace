using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private Player player;

    public void EndLevel()
    {
        SceneManager.LoadScene("Home");
        Debug.Log("Level ended!");
    }
}
