using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerGun : MonoBehaviour {

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float fireRate = 0.1f;

    private float nextFire;
	
	// Update is called once per frame
	void Update () {
        float aimX = CrossPlatformInputManager.GetAxis("WeaponHorizontal");
        float aimY = CrossPlatformInputManager.GetAxis("WeaponVertical");

        Vector3 aim = new Vector3(aimX, 0, aimY);

        if(aim.magnitude > 0.01 && Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.LookRotation(aim));
            nextFire = Time.time + fireRate;
        }
        
    }
}
