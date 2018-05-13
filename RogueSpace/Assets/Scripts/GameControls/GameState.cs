using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;


public class GameState : MonoBehaviour {

    private static GameState INSTANCE;

    [SerializeField]
    private List<ResourceInventoryItem> startingResources = new List<ResourceInventoryItem>();

    public Inventory inventory = new Inventory();
    
    [SerializeField]
    private Gun _defaultGun;

    public ItemLibrary itemLibrary = new ItemLibrary();

    public ShipConfig shipConfig = new ShipConfig();

    DatabaseReference firebase;

    private void Awake()
    {
        if (INSTANCE == null)
        {
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);    
              
    }

    public void SaveState()
    {       
        firebase.Child("users").Child("username")
            .Child("gamestate").Child("inventory")
            .SetRawJsonValueAsync(inventory.ToJson());

        firebase.Child("users").Child("username")
            .Child("gamestate").Child("shipconfig")
            .SetRawJsonValueAsync(shipConfig.ToJson());
    }

    private void Init()
    {        
        INSTANCE = this;        
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://roguespace-gamestate.firebaseio.com/");
        firebase = FirebaseDatabase.DefaultInstance.RootReference;

        itemLibrary.Load();
        LoadInventory();
        
    }

    private void LoadInventory()
    {
        firebase.Child("users").Child("username")
            .Child("gamestate").GetValueAsync()
            .ContinueWith(task => {
                if (task.IsFaulted)
                {
                    // Handle the error...
                    Debug.LogError("Not able to load data from cloud!");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot playergamestate = task.Result;
                    if(playergamestate.Child("inventory").ChildrenCount > 0) {
                        Debug.Log("Loading inventory from cloud");
                        foreach (var child in playergamestate.Child("inventory").Children) {                        
                            string itemKey = (string)child.Child("itemKey").Value;
                            InventoryItem toAdd = itemLibrary.Create(itemKey).InstantiateFromJson(child.GetRawJsonValue());
                            inventory.AddLoot(toAdd);
                        }
                    } else {
                        Debug.Log("Adding initial inventory");
                        AddStartInventory();
                    }

                    string mainGunId = (string)playergamestate.Child("shipconfig").Child("id").Value;
                    Debug.Log(mainGunId);
                    foreach (var item in inventory.items)
                    {
                        Debug.Log(item.GetId());
                        if (item.GetId().Equals(mainGunId))
                        {
                            shipConfig.mainWeapon = item.GetComponent<Gun>();
                            break;
                        }
                    }

                }                         
            })               
            .ContinueWith(task => {
                Debug.Log("Saving state");
                SaveState();
            });      
    }

    private void AddStartInventory()
    {        
        var gun = itemLibrary.Create(_defaultGun.itemLibraryKey);
        inventory.AddLoot(gun);
        Equip(inventory.items[0].GetComponent<Gun>());

        foreach (InventoryItem startingResource in startingResources)
        {
            inventory.AddLoot(itemLibrary.Create(startingResource.itemLibraryKey));
        }
        startingResources.Clear();        
    }

   
    public void Equip(Gun gun)
    {
        Debug.Log(gun.itemName + "equipped in position " + EquipPosition.MAIN_GUN);
        shipConfig.mainWeapon = gun;
        SaveState();
    }
    

    public static GameState Find()
    {
        return GameObject.Find("GameState").GetComponent<GameState>();
    }
    
	
}

[Serializable]
public class ShipConfig
{
    public Gun mainWeapon;

    internal string ToJson()
    {
        return JsonUtility.ToJson(mainWeapon.SerializableValues());
    }
}
