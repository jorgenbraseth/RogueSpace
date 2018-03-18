using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItemResource : UIInventoryItem {

    [SerializeField]
    private Text amountText;

    [SerializeField]
    public ResourceType resourceType;

    void Start()
    {
        GameState state = GameObject.Find("GameState").GetComponent<GameState>();
        if (state.resources.ContainsKey(resourceType))
        {
            SetAmount(state.resources[resourceType]);
        }
        else
        {
            SetAmount(0);
        }
        
    }

    public void SetAmount(int amount)
    {
        amountText.text = amount+"";
        gameObject.SetActive(amount != 0);
    }
}
