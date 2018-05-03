using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInventoryItem : InventoryItem
{
    public int count;
    public string description;
    public string resourceName;
    public ResourceType resourceType;

    public override int GetCount()
    {
        return count;
    }

    public override string GetDescription()
    {
        return description;
    }

    public override EquipPosition GetEquippablePosition()
    {
        return EquipPosition.NONE;
    }

    public override string GetName()
    {
        return resourceName;
    }

    public override string GetProperties()
    {
        return "";
    }

    public override ResourceType GetResourceType()
    {
        return resourceType;
    }

    public override bool IsResource()
    {
        return true;
    }
}
