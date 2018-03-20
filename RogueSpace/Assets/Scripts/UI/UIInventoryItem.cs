using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem: MonoBehaviour, IPointerClickHandler {

    [SerializeField]
    private Color selectedColor = new Color(114,193,255);

    [SerializeField]
    private Color unselectedColor = Color.black;


    [SerializeField]
    private string title;

    [SerializeField]
    private string description;

    [SerializeField]
    private string properties;

    [SerializeField]
    private InventoryManager inventoryManager;

    private InventoryItemDescription itemInfo;

    private void Awake()
    {
        itemInfo = GameObject.Find("ItemInfo").GetComponent<InventoryItemDescription>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryManager.SelectItem(this);
        itemInfo.SetItem(title, description, properties);
    }

    public void Select()
    {
        GetComponent<Image>().color = selectedColor;
    }

    public void Deselect()
    {
        GetComponent<Image>().color = unselectedColor;
    }
}

