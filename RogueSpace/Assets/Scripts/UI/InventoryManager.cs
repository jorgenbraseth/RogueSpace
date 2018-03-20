using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    
    private GameState state;
	
	void Start () {
        state = GameObject.Find("GameState").GetComponent<GameState>();   
    }


    private UIInventoryItem currentlySelected;
    public void SelectItem(UIInventoryItem selected)
    {
        if(currentlySelected != null && currentlySelected != selected)
        {
            currentlySelected.Deselect();
        }
        currentlySelected = selected;
        currentlySelected.Select();
    }
	
}
