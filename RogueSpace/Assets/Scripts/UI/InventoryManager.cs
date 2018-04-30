using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    [SerializeField]
    private UIInventoryItemWeapon inventoryWeaponPrefab;

    private GameState state;
	
	void Start () {
        state = GameObject.Find("GameState").GetComponent<GameState>();   

        foreach (InventoryItem item in state.items)
        {
            Gun gun = item.GetComponent<Gun>();
            if (gun != null)
            {                
                UIInventoryItemWeapon itemIcon = Instantiate(inventoryWeaponPrefab, transform);
                itemIcon.SetItem(gun);                
            }
            
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
