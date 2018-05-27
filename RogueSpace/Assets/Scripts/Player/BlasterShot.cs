using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShot : IBlasterShot {

    [SerializeField]
    private float initialForce = 115f;

    [SerializeField]
    private float ttl = 2f;

    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private GameObject deathEffect;


    [SerializeField]
    private AudioClip hitSound;

    private float spawnTime;

    public override void Configure(int damage)
    {
        this.damage = damage;        
    }

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
        IDamagable enemy = other.GetComponent<IDamagable>();
        if (enemy != null)
        {            
            enemy.Damage(damage, transform.position, transform.forward);
        }
        GameSound.Play(hitSound);
        Die();
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.LookRotation(-1 * transform.eulerAngles));
        Destroy(gameObject);
    }

}
