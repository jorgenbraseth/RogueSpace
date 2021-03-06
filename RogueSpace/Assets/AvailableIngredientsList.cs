﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableIngredientsList : MonoBehaviour
{
    [SerializeField]
    AvailableIngredient ingredientUIPrefab;

    private GameState gamestate;
    private CraftingManager craftingManager;
    private void Start()
    {
        gamestate = GameState.Find();
        craftingManager = CraftingManager.Find();
    }

    private void Clear()
    {
        //Clear existing list
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void Add(InventoryItem item)
    {
        AvailableIngredient added = Instantiate(ingredientUIPrefab, transform);
        added.SetItem(item);        
    }

    public void UpdateList()
    {
        Clear();
        if (craftingManager.currentIngredient == null)
        {
            return;
        }
        if (craftingManager.currentIngredient.IsResource())
        {
            ResourceInventoryItem currentIngredient = (ResourceInventoryItem)craftingManager.currentIngredient;
            foreach (ResourceInventoryItem res in gamestate.inventory.resources)
            {
                if (res.GetResourceType() == currentIngredient.GetResourceType())
                {
                    Add(res);
                }
            }
        }
    }


}
