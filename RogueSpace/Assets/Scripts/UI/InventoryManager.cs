using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField]
    private UIInventoryItem inventoryItemUIPrefab;
   
    private GameState state;
	
	void Start () {
        state = GameState.Find();   

        foreach (InventoryItem item in state.inventory.items)
        {
            Gun gun = item.GetComponent<Gun>();
            if (gun != null)
            {
                UIInventoryItem itemIcon = Instantiate(inventoryItemUIPrefab, transform);
                itemIcon.SetItem(gun);                
            }
            
        }
        foreach (ResourceInventoryItem item in state.inventory.resources)
        {
            UIInventoryItem uiItem = Instantiate(inventoryItemUIPrefab, transform);
            uiItem.SetItem(item);
        }
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
