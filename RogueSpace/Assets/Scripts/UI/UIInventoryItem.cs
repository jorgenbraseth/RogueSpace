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
    private Image icon;

    private InventoryManager inventoryManager;

    private InventoryItemDescription itemInfo;

    [SerializeField]
    private Text amountText;

    [SerializeField]
    public ResourceType resourceType;

    [SerializeField]
    private string title;

    [SerializeField]
    private string description;

    [SerializeField]
    private string properties;

    private InventoryItem item;


    private void Awake()
    {
        itemInfo = GameObject.Find("ItemInfo").GetComponent<InventoryItemDescription>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }


    private void SetAmount(int amount)
    {
        amountText.text = amount + "";
        gameObject.SetActive(amount != 0);
    }


    public void SetIcon(Sprite icon)
    {
        this.icon.sprite = icon;
    }

    public void SetItem(InventoryItem item)
    {
        SetAmount(item.GetCount());
        SetIcon(item.icon);
        this.item = item;
    }

    public void UpdateInfo(InventoryItemDescription ii)
    {
        ii.SetItem(item);
    }
    
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
    
    public EquipPosition EquippablePosition()
    {
        return item.GetEquippablePosition();
    }
}

