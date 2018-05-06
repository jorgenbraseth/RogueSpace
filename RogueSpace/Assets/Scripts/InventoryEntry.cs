using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class InventoryEntry {
    public Dictionary<MaterialProperty, int> properties;
    public string name;
    public string description;
    public int count;
    public ResourceType resourceType;
    public List<EquipPosition> equipPosition = new List<EquipPosition>();

    public string looksId;


    public static InventoryEntry From(InventoryItem item)
    {
        InventoryEntry entry = new InventoryEntry();
        entry.count = item.GetCount();
        entry.description = item.GetDescription();
        entry.name = item.GetName();
        entry.resourceType = item.GetResourceType();
        if(item.GetEquippablePosition() != EquipPosition.NONE)
        {
            entry.equipPosition.Add(item.GetEquippablePosition());
        }
            

        return entry;
    }
}

[System.Serializable]
public class InventoryEntries
{
    public List<InventoryEntry> items = new List<InventoryEntry>();
}
