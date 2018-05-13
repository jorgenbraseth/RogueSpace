using UnityEngine;

[System.Serializable]
public abstract class InventoryItem : MonoBehaviour {
    private string id = System.Guid.NewGuid().ToString();
    public void SetId(string id)
    {
        this.id = id;
        SerializableValues().id = id;
    }
    public string GetId()
    {
        if (id == null)
        {
            SetId(System.Guid.NewGuid().ToString());
        }
        return id;
    }

    public abstract string GetProperties();
    public abstract int GetCount();
    

    public abstract bool IsResource();
    public abstract ResourceType GetResourceType();

    public Sprite icon;
    public string itemName;
    public string itemDescription;
    public string itemLibraryKey;

    public abstract EquipPosition GetEquippablePosition();

    public abstract InventoryItem InstantiateFromJson(string json);

    public abstract SerializableProperties SerializableValues();   
}


