using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvailableIngredient : MonoBehaviour, IPointerClickHandler {

    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text count;
    private InventoryItem item;
    private string description;
    private CraftingManager craftingManager;

    private void Start()
    {
        craftingManager = CraftingManager.Find();
        SetItem(item);
    }


    public void SetItem(InventoryItem item)
    {
        this.item = item;
        icon.sprite = item.icon;
        count.text = "" + item.GetCount();
        count.gameObject.SetActive(item.GetCount() > 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        craftingManager.SelectIngredient(item);
    }
}
