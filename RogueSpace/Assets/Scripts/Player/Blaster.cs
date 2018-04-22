﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Blaster : MonoBehaviour, IGun {   

    [SerializeField]
    private BlasterShot projectile;

    [SerializeField]
    private float fireRate = 0.1f;

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private string name;

    private void Start()
    {
        projectile.Configure(this.damage);
    }    

    private float nextFire;	

    public void Shoot(Vector3 aim)
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile.gameObject, transform.position, Quaternion.LookRotation(aim));
            nextFire = Time.time + fireRate;
        }
    }

    public int GetDamage() { return damage; }

    public string GetDescription()
    {
        return "Blasts stuff";
    }

    public string GetName()
    {
        return name;
    }

    public string GetProperties()
    {
        return damage + " damage";
    }
}
