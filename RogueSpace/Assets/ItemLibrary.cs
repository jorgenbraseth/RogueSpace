using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary {

    private Dictionary<string,InventoryItem> library = new Dictionary<string, InventoryItem>();

    public void Load()
    {
        var items = Resources.LoadAll<InventoryItem>("ItemLibrary/");
        foreach(InventoryItem item in items){
            library.Add(item.itemLibraryKey, item);
        }
        Debug.Log(library.Count + " items loaded into item library");
    }    

    public InventoryItem Create(string itemKey)
    {
        var toclone = library[itemKey];
        var cloned = GameObject.Instantiate<InventoryItem>(toclone);
        cloned.SerializableValues().id = cloned.GetId();

        return cloned;
    }
    
}