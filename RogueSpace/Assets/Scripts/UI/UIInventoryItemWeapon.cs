using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItemWeapon : UIInventoryItem {

    public GameObject weapon;
    private IGun gun;

    void Start()
    {        
       gun = weapon.GetComponent<IGun>();
    }

    override public void UpdateInfo(InventoryItemDescription ii)
    {
        ii.SetItem(gun.GetName(), gun.GetDescription(), gun.GetProperties(), this);
    }

    public override EquipPosition EquippablePosition()
    {
        return EquipPosition.MAIN_GUN;
    }

}
