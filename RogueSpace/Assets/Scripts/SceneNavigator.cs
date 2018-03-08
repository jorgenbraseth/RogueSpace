using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour {

	public void Starmap()
    {
        SceneManager.LoadScene("Game");
    }

    public void Storehouse()
    {
        Debug.Log("Storehouse!");
        //SceneManager.LoadScene("StoreHouse");
    }
}
