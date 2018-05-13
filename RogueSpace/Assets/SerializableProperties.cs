
using UnityEngine;

[System.Serializable]
public abstract class SerializableProperties
{
    [HideInInspector]
    public string id;
    [HideInInspector]
    public string itemKey;


    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
}