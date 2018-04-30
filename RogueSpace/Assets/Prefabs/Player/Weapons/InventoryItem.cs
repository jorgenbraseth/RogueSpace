using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryItem : MonoBehaviour {
    public abstract string GetDescription();
    public abstract string GetName();
    public abstract string GetProperties();

    public Sprite icon;
}
