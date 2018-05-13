using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceInventoryItem : InventoryItem
{

    [SerializeField]
    private ResourceType resourceType;

    public ResourceProperties props;

    private void Awake()
    {
        props.itemKey = itemLibraryKey;
    }

    public override int GetCount()
    {
        return props.count;
    }    

    public override EquipPosition GetEquippablePosition()
    {
        return EquipPosition.NONE;
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

    public override InventoryItem InstantiateFromJson(string json)
    {
        var newprops = JsonUtility.FromJson<ResourceProperties>(json);
        var newme = Instantiate(this);
        newme.props = newprops;
        newme.SetId(newprops.id);
        return newme;
    }    

    internal void AddAmount(int toAdd)
    {
        props.count += toAdd;
    }

    public override SerializableProperties SerializableValues()
    {
        return props;
    }
}

[Serializable]
public class ResourceProperties : SerializableProperties
{
    public int count;
}
