using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NeededIngredient : MonoBehaviour, IPointerClickHandler {

    private CraftingManager craftingManager;
    public InventoryItem ingredient;
    public Image icon;
    public Text text;

    private void Start()
    {
        craftingManager = GameObject.Find("CraftingSystem").GetComponent<CraftingManager>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        craftingManager.SetCurrentIngredient(ingredient);
    }

    private void Update()
    {
        bool fulfilled = craftingManager.IngredientFullfilment[ingredient] != null;
        if (fulfilled) {
            icon.sprite = craftingManager.IngredientFullfilment[ingredient].icon;
        }
        icon.gameObject.SetActive(fulfilled);        
    }


}
