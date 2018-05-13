using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Blaster : Gun {   

    [SerializeField]
    private BlasterShot projectile;
       
    [SerializeField]
    private BlasterProperties props;

    private void Awake()
    {
        props.itemKey = itemLibraryKey;
        projectile.Configure(this.props.damage);
    }    

    private float nextFire;	

    public override void Shoot(Vector3 aim)
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile.gameObject, transform.position, Quaternion.LookRotation(aim));
            nextFire = Time.time + props.fireRate;
        }
    }

    public override int GetDamage() { return props.damage; }   

    public override string GetProperties()
    {
        return props.damage + " damage";
    }

    public override EquipPosition GetEquippablePosition()
    {
        return EquipPosition.MAIN_GUN;
    }
    
    public override InventoryItem InstantiateFromJson(string json)
    {
        var newprops = JsonUtility.FromJson<BlasterProperties>(json);
        var newme = Instantiate(this);
        newme.props = newprops;
        newme.SetId(newprops.id);
        return newme;
    }

    public override SerializableProperties SerializableValues()
    {
        return props;
    }
}

[System.Serializable]
public class BlasterProperties : SerializableProperties
{
    public float fireRate = 0.1f;

    public int damage = 1;
}
