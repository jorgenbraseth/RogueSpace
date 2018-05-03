using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemDescription : MonoBehaviour {

    [SerializeField]
    private Text title;

    [SerializeField]
    private Text description;

    [SerializeField]
    private Text properties;

    [SerializeField]
    private GameObject equipButton;

    private GameState _gameState;

    private InventoryItem _selectedItem;

    private void Start()
    {
        _gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public void SetItem(InventoryItem item)
    {
        _selectedItem = item;
        title.text = item.GetName();
        this.description.supportRichText = true;
        this.description.text = item.GetDescription();
        this.properties.text = item.GetProperties();

        equipButton.SetActive(item.GetEquippablePosition() != EquipPosition.NONE);       
    }

    public void EquipSelected()
    {
        Debug.Log(title.text + "equipped in position " + EquipPosition.MAIN_GUN);
        _gameState.shipConfig.mainWeapon = (Gun)_selectedItem;
    }

}
