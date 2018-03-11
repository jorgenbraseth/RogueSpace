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
	}

    private void FixedUpdate()
    {
        if (Time.time > spawnTime + ttl)
        {            
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {            
            enemy.Damage(damage);
        }
        Die();
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.LookRotation(-1 * transform.eulerAngles));
        Destroy(gameObject);
    }



}
