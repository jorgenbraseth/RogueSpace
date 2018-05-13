using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour {
    
    public List<InventoryItem> ingredients;
    public InventoryItem createsItem;
}


public enum MaterialPropertyThingy
{
    CONDUCTIVITY, TOUGHNESS, REACTIVENESS, WEIGHT
}