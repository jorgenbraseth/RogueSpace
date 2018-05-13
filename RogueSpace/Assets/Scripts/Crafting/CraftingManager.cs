using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour {

    [SerializeField]
    private Blueprint currentBlueprint;

    [SerializeField]
    private GameObject ingredientsPanel;

    [SerializeField]
    private GameObject neededIngredientsList;

    [SerializeField]
    private NeededIngredient neededIngredientPrefab;

    [SerializeField]
    private AvailableIngredientsList availableIngredientsList;

    [SerializeField]
    private Button craftButton;

    public InventoryItem currentIngredient;

    
    public Dictionary<InventoryItem, InventoryItem> IngredientFullfilment = new Dictionary<InventoryItem, InventoryItem>(); 

    private GameState gamestate;

    internal void SetCurrentIngredient(InventoryItem ingredient)
    {
        currentIngredient = ingredient;
        availableIngredientsList.UpdateList();
    }

    
    private void SetBlueprint(Blueprint bp)
    {
        currentBlueprint = bp;
        foreach(InventoryItem ingredient in bp.ingredients)
        {
            InventoryItem needed = Instantiate(ingredient);
            IngredientFullfilment.Add(needed, null);
            NeededIngredient added = Instantiate(neededIngredientPrefab, neededIngredientsList.transform);
            added.ingredient = needed;
            added.text.text = added.ingredient.itemName + " x" + added.ingredient.GetCount();
        }
    }

    internal void SelectIngredient(InventoryItem item)
    {
        IngredientFullfilment[currentIngredient] = item;
    }
    

    private void Start()
    {
        gamestate = GameState.Find();
        SetBlueprint(currentBlueprint);
    }

    private void Update()
    {
        ingredientsPanel.SetActive(currentIngredient != null);
        craftButton.interactable = AllIngredientsFullfilled();
    }

    private bool AllIngredientsFullfilled()
    {
        return !IngredientFullfilment.ContainsValue(null);
    }


    public void Craft()
    {
        foreach(InventoryItem ingredient in currentBlueprint.ingredients)
        {
            gamestate.inventory.RemoveLoot(ingredient);
        }
        gamestate.inventory.AddLoot(gamestate.itemLibrary.Create(currentBlueprint.createsItem.itemLibraryKey));        
        availableIngredientsList.UpdateList();
        gamestate.SaveState();
    }

    public static CraftingManager Find()
    {
        return GameObject.Find("CraftingSystem").GetComponent<CraftingManager>();
    }
}
