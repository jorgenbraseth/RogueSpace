using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public abstract class InventoryItem : MonoBehaviour {
    public abstract string GetDescription();
    public abstract string GetName();
    public abstract string GetProperties();
    public abstract int GetCount();

    public abstract bool IsResource();
    public abstract ResourceType GetResourceType();

    public Sprite icon;

    public abstract EquipPosition GetEquippablePosition();
}
