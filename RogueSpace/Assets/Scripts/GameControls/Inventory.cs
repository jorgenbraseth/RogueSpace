using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Inventory
{
    [SerializeField]
    public List<ResourceInventoryItem> resources = new List<ResourceInventoryItem>();
    public List<InventoryItem> items = new List<InventoryItem>();


    private void AddResource(ResourceInventoryItem loot)
    {
        bool found = false;
        foreach (ResourceInventoryItem res in resources)
        {
            if (res.GetResourceType() == loot.GetResourceType())
            {
                res.AddAmount(loot.GetCount());
                found = true;
                UnityEngine.Object.Destroy(loot);
            }
        }

        if (!found)
        {
            UnityEngine.Object.DontDestroyOnLoad(loot);
            resources.Add(loot);
        }
    }

    private void RemoveResource(ResourceInventoryItem loot)
    {
        List<ResourceInventoryItem> toRemove = new List<ResourceInventoryItem>();
        foreach (ResourceInventoryItem res in resources)
        {
            if (res.GetResourceType() == loot.GetResourceType())
            {
                res.AddAmount(-loot.GetCount());
            }
            if (res.GetCount() <= 0)
            {
                toRemove.Add(res);
            }

        }

        foreach (ResourceInventoryItem res in toRemove)
        {
            resources.Remove(res);
        }
    }
    public void RemoveLoot(InventoryItem loot)
    {
        if (loot.IsResource())
        {
            RemoveResource((ResourceInventoryItem)loot);
        }
        else
        {
            items.Remove(loot);
        }
    }

    public void AddLoot(InventoryItem loot)
    {
        if (loot.IsResource())
        {
            AddResource((ResourceInventoryItem)loot);
        }
        else
        {
            UnityEngine.Object.DontDestroyOnLoad(loot);
            items.Add(loot);
        }
    }

    internal string ToJson()
    {
        List<string> jsonstrings = new List<string>();
        foreach (ResourceInventoryItem item in resources)
        {
            jsonstrings.Add(item.SerializableValues().ToJson());
        }
        foreach (InventoryItem item in items)
        {
            jsonstrings.Add(item.SerializableValues().ToJson());
        }
        string itemstring = String.Join(",", jsonstrings.ToArray());
        return "[" + itemstring + "]";
    }
}
