using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIInventoryItem: MonoBehaviour, IPointerClickHandler {

    [SerializeField]
    private Color selectedColor = new Color(114,193,255);

    [SerializeField]
    private Color unselectedColor = Color.black;

    [SerializeField]
    private Image icon;

    private InventoryManager inventoryManager;

    private InventoryItemDescription itemInfo;

    private void Awake()
    {
        itemInfo = GameObject.Find("ItemInfo").GetComponent<InventoryItemDescription>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

    }

    public void SetIcon(Sprite icon)
    {
        this.icon.sprite = icon;
    }

    abstract public void UpdateInfo(InventoryItemDescription ii);
    
    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryManager.SelectItem(this);
        UpdateInfo(itemInfo);
    }

    public void Select()
    {
        GetComponent<Image>().color = selectedColor;
    }

    public void Deselect()
    {
        GetComponent<Image>().color = unselectedColor;
    }

    public abstract EquipPosition EquippablePosition();
}

