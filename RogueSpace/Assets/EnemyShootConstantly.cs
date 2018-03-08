using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootConstantly : MonoBehaviour {

    [SerializeField]
    private float rateOfFire;

    [SerializeField]
    private GameObject shot;

    [SerializeField]
    private GameObject gun;

    private float nextShotTime;

	
	// Update is called once per frame
	void Update () {

        if (Time.time >= nextShotTime)
        {
            Shoot();
        }
		
	}

    private void Shoot()
    {
        nextShotTime = Time.time + rateOfFire;
        Instantiate(shot, gun.transform.position , gun.transform.rotation);
    }
}
