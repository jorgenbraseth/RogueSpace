using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShot1 : MonoBehaviour {

    [SerializeField]
    private float initialForce = 115f;

    [SerializeField]
    private float ttl = 2f;

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

        if (other.tag == "Player")
        {
            Debug.Log("ouch!");
        }

        Debug.Log(other);
        Destroy(gameObject);
    }

    

}
