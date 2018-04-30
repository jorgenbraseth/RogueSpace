using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItemWeapon : UIInventoryItem {
   
    public Gun gun;

    void Start()
    {        
    }

    override public void UpdateInfo(InventoryItemDescription ii)
    {
        ii.SetItem(gun.GetName(), gun.GetDescription(), gun.GetProperties(), this);
    }

    public override EquipPosition EquippablePosition()
    {
        return EquipPosition.MAIN_GUN;
    }


    public void SetItem(Gun weapon)
    {
        gun = weapon;
        SetIcon(gun.icon);
    }


}
