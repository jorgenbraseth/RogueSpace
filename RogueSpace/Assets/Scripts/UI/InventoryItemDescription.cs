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

    private UIInventoryItemWeapon _selectedItem;

    private void Start()
    {
        _gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }

    public void SetItem(string name, string description, string properties, UIInventoryItemWeapon item)
    {
        _selectedItem = item;
        title.text = name;
        this.description.supportRichText = true;
        this.description.text = description;
        this.properties.text = properties;

        equipButton.SetActive(item != null && item.EquippablePosition() != EquipPosition.NONE);
        

    }

    public void EquipSelected()
    {
        Debug.Log(title.text + "equipped in position " + EquipPosition.MAIN_GUN);
        _gameState.shipConfig.mainWeapon = _selectedItem.gun;
    }

}
