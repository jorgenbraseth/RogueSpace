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


    public void SetItem(string name, string description, string properties)
    {
        title.text = name;
        this.description.supportRichText = true;
        this.description.text = description;
        this.properties.text = properties;
    }

}
