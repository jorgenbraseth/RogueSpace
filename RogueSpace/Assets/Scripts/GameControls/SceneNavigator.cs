using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour {
    
    public void Starmap()
    {
        SceneManager.LoadScene("Game");
    }

    public void Inventory()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

    public void CustomizeShip()
    {
        SceneManager.LoadScene("ShipCustomization");
    }

    public void Crafting()
    {
        SceneManager.LoadScene("Crafting");
    }
}
