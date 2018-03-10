using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot1 : MonoBehaviour {

    [SerializeField]
    private float initialForce = 115f;

    [SerializeField]
    private float ttl = 2f;

    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private GameObject deathEffect;

    private float spawnTime;

	// Use this for initialization
	void Start () {
        spawnTime = Time.time;
        GetComponent<Rigidbody>().AddForce(transform.forward * initialForce);

        Destroy(gameObject, 1);
	}

    private void FixedUpdate()
    {
        if (Time.time > spawnTime + ttl)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {            
            enemy.Damage(damage);
        }
        GameObject death = Instantiate(deathEffect, transform.position, Quaternion.LookRotation(-1 * transform.eulerAngles));
        Destroy(death, 1);

        Destroy(gameObject);
    }

    

}
