using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Blaster : Gun {   

    [SerializeField]
    private BlasterShot projectile;

    [SerializeField]
    private float fireRate = 0.1f;

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private string weaponName;

    private void Start()
    {
        projectile.Configure(this.damage);
    }    

    private float nextFire;	

    public override void Shoot(Vector3 aim)
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile.gameObject, transform.position, Quaternion.LookRotation(aim));
            nextFire = Time.time + fireRate;
        }
    }

    public override int GetDamage() { return damage; }

    public override string GetDescription()
    {
        return "Blasts stuff";
    }

    public override string GetName()
    {
        return weaponName;
    }

    public override string GetProperties()
    {
        return damage + " damage";
    }

    public override EquipPosition GetEquippablePosition()
    {
        return EquipPosition.MAIN_GUN;
    }

}
